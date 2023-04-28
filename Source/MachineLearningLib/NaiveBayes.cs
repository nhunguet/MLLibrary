////import library 

using System;
using System.IO;
using System.Windows.Forms;


namespace MachineLearningLib

{
    public class NaiveBayes

    {

        #region Properties
        private int num_class;

        public int Num_class   // property

        {
            get { return num_class; }   // get method
            set { num_class = value; }  // set method
        }

        /// <summary>
        /// 
        /// set Number of Features 
        /// 
        /// </summary>
        private int num_features;


        public int Num_features// property

        {
            get { return num_features; }   // get method

            set { num_features = value; }  // set method

        }

        private int num_samples;


        /// <summary>
        /// 
        /// //////
        /// Set Num of samples 
        /// </summary>
        public int Num_samples// property

        {
            get { return num_samples; }   // get method
            set { num_samples = value; }  // set method
        }


        #endregion

        #region Constructor / Destructor
        private double[][] data;
        private object means;
        private object variance;

        public double[][] Data
        {

            get { return data; }
            set { this.data = value; }
        }

        public NaiveBayes()

        {

        }
        #endregion

        #region Initialization


        public void Initialization(string path)

        {
            // Load Input Data

            NaiveBayes p = new NaiveBayes();

            p.num_class = 3;

            p.num_features = 4;

            p.num_samples = 117;

            string fn = path;

            double[][] data = p.LoadData(fn, num_samples, num_features, ',');

            MessageBox.Show("Done Load Data");



            //  return data;
        }

        public double[][] LoadData(string fn, int rows, int cols, char delimit)

        {
            // Load data from file to data variable

            // data

            double[][] result = MatrixString(rows, cols);

            FileStream ifs = new FileStream(fn, FileMode.Open);
            StreamReader sr = new StreamReader(ifs);

            string[] tokens = null;
            string line = null;
            int i = 0;


            while ((line = sr.ReadLine()) != null)
            {
                tokens = line.Split(delimit);
                for (int j = 0; j < cols; ++j)
                    result[i][j] = tokens[i][j];
                ++i;
            }
            sr.Close(); ifs.Close();
            return result;

            //   return data.Length;
        }

        /// <summary>
        /// Function 
        /// 
        /// 
        /// </summary>


        public double[][] MatrixString(int rows, int cols)

        {
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            return result;
        }


        #endregion

        #region Setting

        public void Setting()
        {

            MessageBox.Show("Training Data: ");
            // do setting 
            // Get Param 
        }
        #endregion

        #region Training

        public void Training()
        {
            // mean calculation

            NaiveBayes p = new NaiveBayes();

            /// <summary>
            /// Mean calculation for data
            /// </summary>
            /// <param name="input_data"></param>
            /// <returns></returns>
            /// sdfsdf

            //p.MeanCalculation(in_data);





        } 

        //Gause Distribution 

        public double ProbDensFunc(double u, double v, double x)
        
        {
            double left = 1.0 / Math.Sqrt(2 * Math.PI * v);
            double right = Math.Exp(-(x - u) * (x - u) / (2 * v));
            return left * right;
        }
       

        public double[][] MeanCalculation(double[][] in_data)
        
        {
            int[] classCts = new int[num_class];

            double[][] means = new double[num_class][];

            for (int c = 0; c < num_class; ++c)

                means[c] = new double[num_features];

            for (int i = 0; i < num_samples;++i)
            
            {

                int c = (int)data[i][num_features];
                for (int j = 0; j < num_features; ++j)
                    means[c][j] += data[i][j];

            }

            for (int c = 0; c < num_class; ++c)
            {
                for (int j = 0; j < num_features; ++j)
                    means[c][j] /= classCts[c];
            }


            return means;

            // 1. compute means 
            /*double[,] means = new double[1, 1];  // [class][predictor]
            return means;
        */
        }

        /// <summary>
        /// Calculate varian for data
        /// 
        /// 
        /// </summary>
        /// <param name="input_data"></param>
        /// <returns></returns>



        public double[][] varianCalculation(double[][] in_data)
        {
            double[][] variances = new double[num_class][];
            for (int c = 0; c < num_class; ++c)
                variances[c] = new double[num_features];

            for (int i = 0; i < num_samples; ++i)
            {
                int c = (int)data[i][num_features];
                for (int j = 0; j < num_features; ++j)
                {
                    double x = data[i][j];
                    double u = means[c][j];
                    variances[c][j] += (x - u) * (x - u);
                }
            }

            for (int c = 0; c < num_class; ++c)

            {
                for (int j = 0; j < num_features; ++j)
                    variances[c][j] /= classCts[c] - 1;  // sample variance
            }
            return variances;

        }

        /// <summary>
        /// calculate gague for data
        /// </summary>
        /// calculate the data  
        /// 
        /// <param name="means"></param>
        /// <param name="varians"></param>
        /// <returns></returns>
        



        private double[,] GaugeCalculation(double[,] means, double[,] varians)
        
        {
            double[,] gause = new double[1, 1];

            return gause;
 
        }
        
        #endregion

        #region Predict
        
        public void Predict()
        
        {


            double[][] data_test = new double[6][];

            // Set up Data Test
            data_test[0] = new double[] { 4.3, 3.0, 1.1, 0.1 }; // 0 
            data_test[1] = new double[] { 5.1, 3.5, 1.4, 0.2 };  // 0 
            data_test[2] = new double[] { 5.8, 2.7, 4.1, 1.0 };  // 1 
            data_test[3] = new double[] { 6.4, 3.2, 4.5, 1.5 };  // 1 
            data_test[4] = new double[] { 6.3, 3.3, 6.0, 2.5 };  // 2 
            data_test[5] = new double[] { 6.1, 3.0, 4.9, 1.8 };  // 2 

            // set up item to predict


            double[] unk1 = data_test[0];
            double[] unk2 = data_test[1];
            double[] unk3 = data_test[2];
            double[] unk4 = data_test[3];
            double[] unk5 = data_test[4];
            double[] unk6 = data_test[5];


            // 3. conditional probabilities

            double[][] condProbs = new double[num_class][];
            for (int c = 0; c < num_class; ++c)
                condProbs[c] = new double[num_features];

            for (int c = 0; c < num_class; ++c)  // each class

            {
                for (int j = 0; j < num_features; ++j)  // each predictor
                {
                    /*double u = means[c][j];
                    double v = variances[c][j];
                    double x = unk5[j];*/

                    condProbs[c][j] = ProbDensFunc(u, v, x);
                }
            }

        }
        #endregion

        #region Save Model
        public void SaveModel()
        {
            // Serialize 

            // save to file

        }
        #endregion

        #region Load Model
        public void LoadModel()
        {
            // Read file


            // De-Serialize 

            // Create objectgi
        }
        #endregion

    }
}
