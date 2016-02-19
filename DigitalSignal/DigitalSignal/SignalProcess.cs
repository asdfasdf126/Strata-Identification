using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Numerics;

using Slb.Ocean.Core;
using Slb.Ocean.Petrel;
using Slb.Ocean.Petrel.DomainObject;
using Slb.Ocean.Petrel.DomainObject.Basics;
using Slb.Ocean.Petrel.DomainObject.Well;
using Slb.Ocean.Petrel.UI;
using Slb.Ocean.Petrel.Workflow;

using GeoscienceMath;

namespace DigitalSignal
{
    /// <summary>
    /// This class is a standalone Petrel process, cannot be added to a Workflow.
    /// </summary>
    class SignalProcess : Process, IAppearance, IDescriptionSource
    {
        private BoreholeCollection procBHC;


        /// <summary>
        /// Constructor.
        /// </summary>
        public SignalProcess() : base("SignalProcess")
        {
        }

        public void updateWells(List<Borehole> bhs, ValidateRange vr)
        {
            IProgress pb;
            int max = 0;
            Dictionary<int, double> weights;
            double[] gr = null, nphi = null, rhoz = null,
                pef = null, rid = null, rim = null, cali = null,
                md = null;

            foreach (Borehole bh in bhs)
            {
                max+=2;
                foreach (WellLog wl in bh.Logs.WellLogs)
                    if (isGoodLog(wl) && !wl.Name.Contains("Processed"))
                        max += 2;
                    else if (wl.Name.Contains("Processed") || wl.WellLogVersion.Name == "Shale Probability")
                        max++;
            }

            pb = PetrelLogger.NewProgress(0, max, ProgressType.Default, 
                System.Windows.Forms.Cursors.WaitCursor);

            pb.SetProgressText("Cleaning Project");

            foreach (Borehole bh in bhs)
                foreach(WellLog wl in bh.Logs.WellLogs)
                    if (wl.Name.Contains("Processed") || wl.WellLogVersion.Name == "Shale Probability")
                    {
                        remove(wl);
                        pb.ProgressStatus++;
                    }

            foreach (Borehole bh in bhs)
            {
                pb.SetProgressText("Processing..." + bh.Name);
                weights = new Dictionary<int, double>();

                foreach (WellLog wl in bh.Logs.WellLogs)
                {
                    if (isGoodLog(wl))
                    {
                        double[] value = new double[wl.SampleCount];
                        md = new double[wl.SampleCount];
                        int count = 0;
                        Template t = getOrCreateTemplate(wl);
                        string wlvName = wl.WellLogVersion.Name + " [Processed]";

                        pb.SetProgressText("Retrieving..." + bh.Name + " " + wl.Name);

                        foreach (WellLogSample wls in wl.Samples)
                        {
                            md[count] = wls.MD;
                            value[count++] = wls.Value;
                        }

                        pb.ProgressStatus++;
                        pb.SetProgressText("Filtering..." + bh.Name + " " + wl.Name);

                        updateWells(md, value, bh, t, wlvName);
                        //value = deconvolution(value);

                        switch (wl.Name)
                        {
                            case "GR": gr = value;
                                break;
                            case "NPHI": nphi = value;
                                break;
                            case "RHOZ": rhoz = value;
                                break;
                            case "PEF": pef = value;
                                break;
                            case "RID": rid = value;
                                break;
                            case "RIM": rim = value;
                                break;
                            case "CALI": cali = value;
                                break;
                        }
                        

                        pb.ProgressStatus++;
                    }
                }

                pb.SetProgressText("Calculating Shale Probability");

                for (int x = 0; x < gr.Length; x++)
                {
                    double sum = 0;
                    sum += vr.checkRange(LogTypes.GR, gr[x]);

                    if (sum > 0)
                    {
                        if (x < rhoz.Length)
                            sum += vr.checkRange(LogTypes.RHOZ, rhoz[x]);

                        if (x < nphi.Length)
                            sum += vr.checkRange(LogTypes.NPHI, nphi[x]);

                        if (x < rid.Length)
                            sum += vr.checkRange(LogTypes.RID, rid[x]);

                        if (x < rim.Length)
                            sum += vr.checkRange(LogTypes.RIM, rim[x]);

                        if (x < pef.Length)
                            sum += vr.checkRange(LogTypes.PEF, pef[x]);

                        if (x < cali.Length)
                            sum += vr.checkRange(LogTypes.CALI, cali[x]);
                    }

                    weights.Add(x, sum);
                }
                pb.ProgressStatus++;
                pb.SetProgressText("Creating shale log");
                createLog(weights, md, bh);
                pb.ProgressStatus++;
            }

            //getOriginal(bhs, vr);

            pb.Dispose();
        }

        private double[] deconvolution(double[] values)
        {
            Complex[] a = new Complex[values.Length];
            Complex[] b = new Complex[values.Length];
            Complex[] c;
            double[] output = new double[values.Length];

            for (int z = 0; z < b.Length; z++)
            {
                a[z] = new Complex(WellLogging.gaussian(z), 0);
                b[z] = values[z];
            }

            c = WellLogging.deConvolution(b, a);

            for (int z = 0; z < c.Length; z++)
                output[z] = c[z].Real;

            return output;
        }

        private void getOriginal(List<Borehole> bhs, ValidateRange vr)
        {
            int max = 0;
            Dictionary<int, double> weights;
            double[] gr = null, nphi = null, rhoz = null,
                pef = null, rid = null, rim = null, cali = null,
                md = null;

            foreach (Borehole bh in bhs)
            {
                max += 2;
                foreach (WellLog wl in bh.Logs.WellLogs)
                    if (isGoodLog(wl) && !wl.Name.Contains("Processed"))
                        max += 2;
            }

            foreach (Borehole bh in bhs)
            {
                weights = new Dictionary<int, double>();

                foreach (WellLog wl in bh.Logs.WellLogs)
                {
                    if (isGoodLog(wl))
                    {
                        double[] value = new double[wl.SampleCount];
                        md = new double[wl.SampleCount];
                        int count = 0;
                        Template t = getOrCreateTemplate(wl);
                        string wlvName = wl.WellLogVersion.Name + " [Processed]";

                        foreach (WellLogSample wls in wl.Samples)
                        {
                            md[count] = wls.MD;
                            value[count++] = wls.Value;
                        }

                        switch (wl.Name)
                        {
                            case "GR": gr = value;
                                break;
                            case "NPHI": nphi = value;
                                break;
                            case "RHOZ": rhoz = value;
                                break;
                            case "PEF": pef = value;
                                break;
                            case "RID": rid = value;
                                break;
                            case "RIM": rim = value;
                                break;
                            case "CALI": cali = value;
                                break;
                        }
                    }
                }

                for (int x = 0; x < gr.Length; x++)
                {
                    double sum = 0;
                    sum += vr.checkRange(LogTypes.GR, gr[x]);

                    if (sum > 0)
                    {
                        if (x < rhoz.Length)
                            sum += vr.checkRange(LogTypes.RHOZ, rhoz[x]);

                        if (x < nphi.Length)
                            sum += vr.checkRange(LogTypes.NPHI, nphi[x]);

                        if (x < rid.Length)
                            sum += vr.checkRange(LogTypes.RID, rid[x]);

                        if (x < rim.Length)
                            sum += vr.checkRange(LogTypes.RIM, rim[x]);

                        if (x < pef.Length)
                            sum += vr.checkRange(LogTypes.PEF, pef[x]);

                        if (x < cali.Length)
                            sum += vr.checkRange(LogTypes.CALI, cali[x]);
                    }

                    weights.Add(x, sum);
                }

                createLog(weights, md, bh, false);
            }
        }

        private void remove(WellLog wl)
        {
            using (ITransaction trans = DataManager.NewTransaction())
            {

                trans.Lock(wl);
                wl.Delete();
                trans.Commit();
            }
        }

        private Template getOrCreateTemplate(WellLog wl)
        {
            // create custom template with more detailed info
            Borehole bh = wl.Borehole;
            Template t = wl.WellLogVersion.Template;
            ITemplateSettingsInfoFactory factory = CoreSystem.GetService<ITemplateSettingsInfoFactory>(t);
            TemplateCollection parent = PetrelProject.WellKnownTemplateCollections.LogTypes;
            TemplateSettingsInfo info = factory.GetTemplateSettingsInfo(t);
            ITemplateService ts = PetrelSystem.TemplateService;
            string newName = ts.GetUniqueName(wl.Name + " [Processed]");
            Template newTWT = Template.NullObject;

            if (newTWT == Template.NullObject)
            {
                using (ITransaction txn = DataManager.NewTransaction())
                {
                    txn.Lock(parent);
                    newTWT = parent.CreateTemplate(newName, info.DefaultColorTable, t.UnitMeasurement);
                    newTWT.Comments = t.Comments + " [Processed]";
                    newTWT.TemplateType = t.TemplateType;
                    txn.Commit();
                }

                factory = CoreSystem.GetService<ITemplateSettingsInfoFactory>(newTWT);
                TemplateSettingsInfo info2 = factory.GetTemplateSettingsInfo(newTWT);
                info2.NumericPrecision = new NumericPrecision(6, WellKnownPrecisionTypes.DecimalPlaces);
            }

            return t;
        }

        //shale probability log
        private void createLog(Dictionary<int, double> weights, double[] md, Borehole bh, bool proc = false)
        {
            double[] value = weights.Values.ToArray<double>();

            // create custom template with more detailed info
            Template t = PetrelProject.WellKnownTemplates.MiscellaneousGroup.Probability;
            ITemplateSettingsInfoFactory factory = CoreSystem.GetService<ITemplateSettingsInfoFactory>(t);
            TemplateCollection parent = PetrelProject.WellKnownTemplateCollections.LogTypes;
            TemplateSettingsInfo info = factory.GetTemplateSettingsInfo(t);
            ITemplateService ts = PetrelSystem.TemplateService;
            string newName = ts.GetUniqueName("ShaleProbability");
            Template newTWT = Template.NullObject;

            if (newTWT == Template.NullObject)
            {
                using (ITransaction txn = DataManager.NewTransaction())
                {
                    txn.Lock(parent);
                    newTWT = parent.CreateTemplate(newName, info.DefaultColorTable, t.UnitMeasurement);
                    newTWT.Comments = "Shale Probability";
                    newTWT.TemplateType = TemplateType.Probability;
                    txn.Commit();
                }

                factory = CoreSystem.GetService<ITemplateSettingsInfoFactory>(newTWT);
                TemplateSettingsInfo info2 = factory.GetTemplateSettingsInfo(newTWT);
                info2.NumericPrecision = new NumericPrecision(6, WellKnownPrecisionTypes.DecimalPlaces);
            }

            string name = "Shale Probability";

            if (proc)
                name += " [Processed]";

            updateWells(md, value, bh, t , name);
        }

        //depth log
        private void createLog(double[] md, string name)
        {
            // create custom template with more detailed info
            Template t = PetrelProject.WellKnownTemplates.MiscellaneousGroup.TotalDepth;
            ITemplateSettingsInfoFactory factory = CoreSystem.GetService<ITemplateSettingsInfoFactory>(t);
            TemplateCollection parent = PetrelProject.WellKnownTemplateCollections.LogTypes;
            TemplateSettingsInfo info = factory.GetTemplateSettingsInfo(t);
            ITemplateService ts = PetrelSystem.TemplateService;
            string newName = ts.GetUniqueName("Depth");
            Template newTWT = Template.NullObject;

            using (ITransaction txn = DataManager.NewTransaction())
            {
                txn.Lock(parent);
                newTWT = parent.CreateTemplate(newName, info.DefaultColorTable, t.UnitMeasurement);
                newTWT.Comments = "Depth";
                newTWT.TemplateType = TemplateType.Probability;
                txn.Commit();
            }

            factory = CoreSystem.GetService<ITemplateSettingsInfoFactory>(newTWT);
            TemplateSettingsInfo info2 = factory.GetTemplateSettingsInfo(newTWT);
            info2.NumericPrecision = new NumericPrecision(6, WellKnownPrecisionTypes.DecimalPlaces);

            //updateWells(md, md, name, t, "Depth");
        }

        private double[] getSamples(WellLog wl)
        {
            double[] samples = new double[wl.SampleCount];
            int count = 0;

            foreach (WellLogSample sample in wl.Samples)
                samples[count++] = sample.Value;

            return samples;
        }

        private bool isGoodLog(WellLog wl)
        {
            Template t = wl.WellLogVersion.Template;

            return t.TemplateType == TemplateType.GammaRay || t.TemplateType == TemplateType.Neutron ||
                   t.TemplateType == TemplateType.Caliper || t.TemplateType == TemplateType.ResistivityDeep ||
                   t.TemplateType == TemplateType.ResistivityMedium || t.TemplateType == TemplateType.Pef ||
                   t.TemplateType == TemplateType.DensityCompensatedBulk;
        }

        private Borehole getBoreHoleCollection(WellRoot wr, string bhName)
        {
            ITransaction trans;
            BoreholeCollection rootBhc;
            Borehole bh = Borehole.NullObject;

            using (trans = DataManager.NewTransaction())
            {
                trans.Lock(wr);

                //Create borehole collection and grab it for processing
                rootBhc = wr.GetOrCreateBoreholeCollection();

                if (procBHC == null)
                    procBHC = rootBhc.CreateBoreholeCollection("Processed Wells");
                else
                    trans.Lock(procBHC);

                if(procBHC.FindWellByUWI(bhName) == null) 
                {
                    bh = procBHC.CreateBorehole(bhName) ;
                    bh.UWI = bhName;
                }
                else
                    bh = procBHC.FindWellByUWI(bhName);

                trans.Commit();
            }

            return bh;
        }

        private WellRoot getWellRoot()
        {
            Project proj = PetrelProject.PrimaryProject;
            WellRoot wr = WellRoot.Get(proj);
            return wr;
        }

        private WellLogSample[] createSamples(double[] x, double[] y)
        {
            WellLogSample[] sample = new WellLogSample[x.Length];
            //y = Filter.avgFilter(x, y);
            y = Filter.CleanData(y, 501, .98);

            for(int z = 0; z < x.Length; z++)
                sample[z] = new WellLogSample(x[z], (float) y[z]);

            return sample;
        }

        public double[] updateWells(double[] x, double[] y, Borehole bh, Template t, string wlvName)
        {
            ITransaction trans;
            WellRoot wr = getWellRoot();
            WellLogVersion wlv = WellLogVersion.NullObject;
            WellLogSample[] sample = createSamples(x, y);
            IEnumerable<WellLogVersion> wlvs = bh.Logs.FindUnusedWellLogVersions(t);
            
            using (trans = DataManager.NewTransaction())
            {
                if (wlvs.Count() > 0)
                    wlv = wlvs.First();
                else
               {
                    LogVersionCollection lvc = wr.LogVersionCollection;
                    trans.Lock(lvc);
                    wlv = lvc.CreateWellLogVersion(wlvName, t);
                }

                trans.Lock(bh);
                WellLog log = bh.Logs.CreateWellLog(wlv);

                log.Samples = sample;

                trans.Commit();
            }

            double[] outp = new double[sample.Length];
            
            for(int z = 0; z < outp.Length; z++)
                outp[z] = sample.ElementAt(z).Value;

            return outp;
        }

        private void testing()
        {
            string[] gr = File.ReadAllLines(@"C:\Users\Group10\Desktop\GR.csv");
            double[] x = new double[gr.Length];
            double[] y = new double[gr.Length];
            int count = 0;

            foreach (string line in gr)
            {
                string[] value = line.Split(',');
                x[count] = double.Parse(value[0]);
                y[count++] = double.Parse(value[1]);
            }

            //updateWells(x, y);
        }

        #region Process overrides

        /// <summary>
        /// Creates the UI of the process.
        /// </summary>
        /// <returns>the UI contol</returns>
        protected override System.Windows.Forms.Control CreateUICore()
        {
            return new SignalProcessUI(this);
        }

        /// <summary>
        /// Runs when the process is activated in Petrel.
        /// </summary>
        protected override sealed void OnActivateCore()
        {
            base.OnActivateCore();
            testing();
        }
        /// <summary>
        /// Runs when the process is deactivated in Petrel.
        /// </summary>
        protected override sealed void OnDeactivateCore()
        {
            base.OnDeactivateCore();
        }

        /// <summary>
        /// Gets the unique identifier for this Process.
        /// </summary>
        protected override string UniqueIdCore
        {
            get
            {
                return "064312c5-47c6-4ce4-b129-c5928418887b";
            }
        }

        #endregion

        #region IAppearance Members
        public event EventHandler<TextChangedEventArgs> TextChanged;
        protected void RaiseTextChanged()
        {
            if (this.TextChanged != null)
                this.TextChanged(this, new TextChangedEventArgs(this));
        }

        public string Text
        {
            get { return Description.Name; }
            private set 
            {
                // TODO: implement set
                this.RaiseTextChanged();
            }
        }

        public event EventHandler<ImageChangedEventArgs> ImageChanged;
        protected void RaiseImageChanged()
        {
            if (this.ImageChanged != null)
                this.ImageChanged(this, new ImageChangedEventArgs(this));
        }

        public System.Drawing.Bitmap Image
        {
            get { return PetrelImages.Modules; }
            private set 
            {
                // TODO: implement set
                this.RaiseImageChanged();
            }
        }
        #endregion

        #region IDescriptionSource Members

        /// <summary>
        /// Gets the description of the SignalProcess
        /// </summary>
        public IDescription Description
        {
            get { return SignalProcessDescription.Instance; }
        }

        /// <summary>
        /// This singleton class contains the description of the SignalProcess.
        /// Contains Name, Shorter description and detailed description.
        /// </summary>
        public class SignalProcessDescription : IDescription
        {
            /// <summary>
            /// Contains the singleton instance.
            /// </summary>
            private  static SignalProcessDescription instance = new SignalProcessDescription();
            /// <summary>
            /// Gets the singleton instance of this Description class
            /// </summary>
            public static SignalProcessDescription Instance
            {
                get { return instance; }
            }

            #region IDescription Members

            /// <summary>
            /// Gets the name of SignalProcess
            /// </summary>
            public string Name
            {
                get { return "SignalProcess"; }
            }
            /// <summary>
            /// Gets the short description of SignalProcess
            /// </summary>
            public string ShortDescription
            {
                get { return ""; }
            }
            /// <summary>
            /// Gets the detailed description of SignalProcess
            /// </summary>
            public string Description
            {
                get { return ""; }
            }

            #endregion
        }
        #endregion
    }
}