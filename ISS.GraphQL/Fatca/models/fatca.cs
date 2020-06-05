//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;

//namespace ISWebApp.GraphQL.Fatca.models
//{
//    public partial class Fatca
//    {

//        private string accountNumberField;

//        private List<FatcaQuestions> questionnaireField;

//        private ContactDetails contactDetailsField;

//        private AccountDetailsBasic accountDetailsField;

//        private GeneralAccountId requestField;

//        private static System.Xml.Serialization.XmlSerializer serializer;

//        public Fatca()
//        {
//            this.requestField = new GeneralAccountId();
//            this.accountDetailsField = new AccountDetailsBasic();
//            this.contactDetailsField = new ContactDetails();
//            this.questionnaireField = new List<FatcaQuestions>();
//        }

//        public string AccountNumber
//        {
//            get
//            {
//                return this.accountNumberField;
//            }
//            set
//            {
//                this.accountNumberField = value;
//            }
//        }

//        [System.Xml.Serialization.XmlElementAttribute("Questionnaire")]
//        public List<FatcaQuestions> Questionnaire
//        {
//            get
//            {
//                return this.questionnaireField;
//            }
//            set
//            {
//                this.questionnaireField = value;
//            }
//        }

//        public ContactDetails ContactDetails
//        {
//            get
//            {
//                return this.contactDetailsField;
//            }
//            set
//            {
//                this.contactDetailsField = value;
//            }
//        }

//        public AccountDetailsBasic AccountDetails
//        {
//            get
//            {
//                return this.accountDetailsField;
//            }
//            set
//            {
//                this.accountDetailsField = value;
//            }
//        }

//        public GeneralAccountId Request
//        {
//            get
//            {
//                return this.requestField;
//            }
//            set
//            {
//                this.requestField = value;
//            }
//        }

//        private static System.Xml.Serialization.XmlSerializer Serializer
//        {
//            get
//            {
//                if ((serializer == null))
//                {
//                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(Fatca));
//                }
//                return serializer;
//            }
//        }

//        #region Serialize/Deserialize
//        /// <summary>
//        /// Serializes current Fatca object into an XML document
//        /// </summary>
//        /// <returns>string XML value</returns>
//        public virtual string Serialize()
//        {
//            System.IO.StreamReader streamReader = null;
//            System.IO.MemoryStream memoryStream = null;
//            try
//            {
//                memoryStream = new System.IO.MemoryStream();
//                Serializer.Serialize(memoryStream, this);
//                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
//                streamReader = new System.IO.StreamReader(memoryStream);
//                return streamReader.ReadToEnd();
//            }
//            finally
//            {
//                if ((streamReader != null))
//                {
//                    streamReader.Dispose();
//                }
//                if ((memoryStream != null))
//                {
//                    memoryStream.Dispose();
//                }
//            }
//        }

//        public static bool Deserialize(string xml, out Fatca obj, out System.Exception exception)
//        {
//            exception = null;
//            obj = default(Fatca);
//            try
//            {
//                obj = Deserialize(xml);
//                return true;
//            }
//            catch (System.Exception ex)
//            {
//                exception = ex;
//                return false;
//            }
//        }

//        public static bool Deserialize(string xml, out Fatca obj)
//        {
//            System.Exception exception = null;
//            return Deserialize(xml, out obj, out exception);
//        }

//        public static Fatca Deserialize(string xml)
//        {
//            System.IO.StringReader stringReader = null;
//            try
//            {
//                stringReader = new System.IO.StringReader(xml);
//                return ((Fatca)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
//            }
//            finally
//            {
//                if ((stringReader != null))
//                {
//                    stringReader.Dispose();
//                }
//            }
//        }

//        /// <summary>
//        /// Serializes current Fatca object into file
//        /// </summary>
//        /// <param name="fileName">full path of outupt xml file</param>
//        /// <param name="exception">output Exception value if failed</param>
//        /// <returns>true if can serialize and save into file; otherwise, false</returns>
//        public virtual bool SaveToFile(string fileName, out System.Exception exception)
//        {
//            exception = null;
//            try
//            {
//                SaveToFile(fileName);
//                return true;
//            }
//            catch (System.Exception e)
//            {
//                exception = e;
//                return false;
//            }
//        }

//        public virtual void SaveToFile(string fileName)
//        {
//            System.IO.StreamWriter streamWriter = null;
//            try
//            {
//                string xmlString = Serialize();
//                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
//                streamWriter = xmlFile.CreateText();
//                streamWriter.WriteLine(xmlString);
//                streamWriter.Close();
//            }
//            finally
//            {
//                if ((streamWriter != null))
//                {
//                    streamWriter.Dispose();
//                }
//            }
//        }

//        /// <summary>
//        /// Deserializes xml markup from file into an Fatca object
//        /// </summary>
//        /// <param name="fileName">string xml file to load and deserialize</param>
//        /// <param name="obj">Output Fatca object</param>
//        /// <param name="exception">output Exception value if deserialize failed</param>
//        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
//        public static bool LoadFromFile(string fileName, out Fatca obj, out System.Exception exception)
//        {
//            exception = null;
//            obj = default(Fatca);
//            try
//            {
//                obj = LoadFromFile(fileName);
//                return true;
//            }
//            catch (System.Exception ex)
//            {
//                exception = ex;
//                return false;
//            }
//        }

//        public static bool LoadFromFile(string fileName, out Fatca obj)
//        {
//            System.Exception exception = null;
//            return LoadFromFile(fileName, out obj, out exception);
//        }

//        public static Fatca LoadFromFile(string fileName)
//        {
//            System.IO.FileStream file = null;
//            System.IO.StreamReader sr = null;
//            try
//            {
//                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
//                sr = new System.IO.StreamReader(file);
//                string xmlString = sr.ReadToEnd();
//                sr.Close();
//                file.Close();
//                return Deserialize(xmlString);
//            }
//            finally
//            {
//                if ((file != null))
//                {
//                    file.Dispose();
//                }
//                if ((sr != null))
//                {
//                    sr.Dispose();
//                }
//            }
//        }
//        #endregion
//    }
//    public partial class FatcaQuestions
//    {

//        private string questionField;

//        private string answerField;

//        private FatcaSubQuestions subQuestionsField;

//        private static System.Xml.Serialization.XmlSerializer serializer;

//        public FatcaQuestions()
//        {
//            this.subQuestionsField = new FatcaSubQuestions();
//        }

//        public string Question
//        {
//            get
//            {
//                return this.questionField;
//            }
//            set
//            {
//                this.questionField = value;
//            }
//        }

//        public string Answer
//        {
//            get
//            {
//                return this.answerField;
//            }
//            set
//            {
//                this.answerField = value;
//            }
//        }

//        public  FatcaSubQuestions SubQuestions
//        {
//            get
//            {
//                return this.subQuestionsField;
//            }
//            set
//            {
//                this.subQuestionsField = value;
//            }
//        }

//        private static System.Xml.Serialization.XmlSerializer Serializer
//        {
//            get
//            {
//                if ((serializer == null))
//                {
//                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(FatcaQuestions));
//                }
//                return serializer;
//            }
//        }

//        #region Serialize/Deserialize
//        /// <summary>
//        /// Serializes current FatcaQuestions object into an XML document
//        /// </summary>
//        /// <returns>string XML value</returns>
//        public virtual string Serialize()
//        {
//            System.IO.StreamReader streamReader = null;
//            System.IO.MemoryStream memoryStream = null;
//            try
//            {
//                memoryStream = new System.IO.MemoryStream();
//                Serializer.Serialize(memoryStream, this);
//                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
//                streamReader = new System.IO.StreamReader(memoryStream);
//                return streamReader.ReadToEnd();
//            }
//            finally
//            {
//                if ((streamReader != null))
//                {
//                    streamReader.Dispose();
//                }
//                if ((memoryStream != null))
//                {
//                    memoryStream.Dispose();
//                }
//            }
//        }

//        /// <summary>
//        /// Deserializes workflow markup into an FatcaQuestions object
//        /// </summary>
//        /// <param name="xml">string workflow markup to deserialize</param>
//        /// <param name="obj">Output FatcaQuestions object</param>
//        /// <param name="exception">output Exception value if deserialize failed</param>
//        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
//        public static bool Deserialize(string xml, out FatcaQuestions obj, out System.Exception exception)
//        {
//            exception = null;
//            obj = default(FatcaQuestions);
//            try
//            {
//                obj = Deserialize(xml);
//                return true;
//            }
//            catch (System.Exception ex)
//            {
//                exception = ex;
//                return false;
//            }
//        }

//        public static bool Deserialize(string xml, out FatcaQuestions obj)
//        {
//            System.Exception exception = null;
//            return Deserialize(xml, out obj, out exception);
//        }

//        public static FatcaQuestions Deserialize(string xml)
//        {
//            System.IO.StringReader stringReader = null;
//            try
//            {
//                stringReader = new System.IO.StringReader(xml);
//                return ((FatcaQuestions)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
//            }
//            finally
//            {
//                if ((stringReader != null))
//                {
//                    stringReader.Dispose();
//                }
//            }
//        }

//        /// <summary>
//        /// Serializes current FatcaQuestions object into file
//        /// </summary>
//        /// <param name="fileName">full path of outupt xml file</param>
//        /// <param name="exception">output Exception value if failed</param>
//        /// <returns>true if can serialize and save into file; otherwise, false</returns>
//        public virtual bool SaveToFile(string fileName, out System.Exception exception)
//        {
//            exception = null;
//            try
//            {
//                SaveToFile(fileName);
//                return true;
//            }
//            catch (System.Exception e)
//            {
//                exception = e;
//                return false;
//            }
//        }

//        public virtual void SaveToFile(string fileName)
//        {
//            System.IO.StreamWriter streamWriter = null;
//            try
//            {
//                string xmlString = Serialize();
//                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
//                streamWriter = xmlFile.CreateText();
//                streamWriter.WriteLine(xmlString);
//                streamWriter.Close();
//            }
//            finally
//            {
//                if ((streamWriter != null))
//                {
//                    streamWriter.Dispose();
//                }
//            }
//        }

//        /// <summary>
//        /// Deserializes xml markup from file into an FatcaQuestions object
//        /// </summary>
//        /// <param name="fileName">string xml file to load and deserialize</param>
//        /// <param name="obj">Output FatcaQuestions object</param>
//        /// <param name="exception">output Exception value if deserialize failed</param>
//        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
//        public static bool LoadFromFile(string fileName, out FatcaQuestions obj, out System.Exception exception)
//        {
//            exception = null;
//            obj = default(FatcaQuestions);
//            try
//            {
//                obj = LoadFromFile(fileName);
//                return true;
//            }
//            catch (System.Exception ex)
//            {
//                exception = ex;
//                return false;
//            }
//        }

//        public static bool LoadFromFile(string fileName, out FatcaQuestions obj)
//        {
//            System.Exception exception = null;
//            return LoadFromFile(fileName, out obj, out exception);
//        }

//        public static FatcaQuestions LoadFromFile(string fileName)
//        {
//            System.IO.FileStream file = null;
//            System.IO.StreamReader sr = null;
//            try
//            {
//                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
//                sr = new System.IO.StreamReader(file);
//                string xmlString = sr.ReadToEnd();
//                sr.Close();
//                file.Close();
//                return Deserialize(xmlString);
//            }
//            finally
//            {
//                if ((file != null))
//                {
//                    file.Dispose();
//                }
//                if ((sr != null))
//                {
//                    sr.Dispose();
//                }
//            }
//        }
//        #endregion
//    }
//}
