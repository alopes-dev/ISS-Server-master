//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using System.Xml;

//namespace ISWebApp.GraphQL.Fatca.models
//{
//    class Class1
//    {
//        public void st()
//        {
//            XmlDocument xmlDocument = new XmlDocument();

//            var fataQuestionnaire = @"<?xml version=""1.0"" encoding=""UTF-16""?>
//                    <FatcaQuestionnaire xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
//                      <QuestionAnswers>
//                        <QuestionAnswer>
//                          <Question>What is your source of wealth?</Question>
//                          <Answer>I am italian </Answer>
//                        </QuestionAnswer>
//                        <QuestionAnswer>
//                          <Question>What is your occupation and name of employer?</Question>
//                          <Answer>Bestinvest</Answer>
//                        </QuestionAnswer>
//                        <QuestionAnswer>
//                          <Question>Do you have a business or residence in?</Question>
//                          <Answer>Yes</Answer>
//                        </QuestionAnswer>
//                        <QuestionAnswer>
//                          <Question>How long have you lived outside of Albania</Question>
//                          <Answer>5 years</Answer>
//                        </QuestionAnswer>
//                        <QuestionAnswer>
//                          <Question>Do you return to Albania on a regular basis</Question>
//                          <Answer>Yes</Answer>
//                          <SubQuestionAnswer>
//                            <Question>How frequently?</Question>
//                            <Answer>every year</Answer>
//                          </SubQuestionAnswer>
//                        </QuestionAnswer>
//                        <QuestionAnswer>
//                          <Question>Do you have family in Albania?</Question>
//                          <Answer>Yes</Answer>
//                          <SubQuestionAnswer>
//                            <Question>Family relationship?</Question>
//                            <Answer>My parents lives there</Answer>
//                          </SubQuestionAnswer>
//                        </QuestionAnswer>
//                        <QuestionAnswer>
//                          <Question>Are you connected to the government of Albania?</Question>
//                          <Answer>Yes</Answer>
//                          <SubQuestionAnswer>
//                            <Question>Nature of association</Question>
//                            <Answer>I was an ex minister</Answer>
//                          </SubQuestionAnswer>
//                        </QuestionAnswer>
//                        <QuestionAnswer>
//                          <Question>Do you send or receive money from Albania?</Question>
//                          <Answer>Yes</Answer>
//                          <SubQuestionAnswer>
//                            <Question>How often and why?</Question>
//                            <Answer>Every month for my parents to live with.</Answer>
//                          </SubQuestionAnswer>
//                        </QuestionAnswer>
//                      </QuestionAnswers>
//                    </FatcaQuestionnaire>";

//            XmlTextReader reader = new XmlTextReader(new StringReader(fataQuestionnaire));
//            xmlDocument.Load(reader);
//            XmlElement xmlRoot = xmlDocument.DocumentElement;
//            if (xmlRoot != null)
//            {
//                XmlNodeList xnlNodes = xmlRoot.SelectNodes("/FatcaQuestionnaire/QuestionAnswers/QuestionAnswer");
//                foreach (XmlNode xndNode in xnlNodes)
//                {
//                    foreach (var qa in fataQuestionnaire.Q)
//                    {
//                        if (xndNode["Question"] != null)
//                            qa.Question = xndNode["Question"].InnerText;

//                        if (xndNode["Answer"] != null)
//                            qa.Answer = xndNode["Answer"].InnerText;
//                    }
//                }
//            }
//        }
//    }

