using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using BROWSit.Models;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using Wp = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using Pic = DocumentFormat.OpenXml.Drawing.Pictures;
using A14 = DocumentFormat.OpenXml.Office2010.Drawing;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using V = DocumentFormat.OpenXml.Vml;
using M = DocumentFormat.OpenXml.Math;
using W15 = DocumentFormat.OpenXml.Office2013.Word;
using Op = DocumentFormat.OpenXml.CustomProperties;

namespace BROWSit.Helpers
{
    public class WordHelper
    {
        public static void exportToWord(GenerateModel model)
        {
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
            response.AddHeader("Content-Disposition", "attachment; filename=" + model.temporarySRS.Filename + ".docx;");
            using (MemoryStream stream = new MemoryStream())
            {
                using (WordprocessingDocument document = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document))
                {
                    CreateParts(document, model);
                }
                stream.WriteTo(response.OutputStream);
                stream.Close();
            }
            response.End();
        }

        // Adds child parts and generates content of the specified part.
        public static void CreateParts(WordprocessingDocument document, GenerateModel model)
        {
            ExtendedFilePropertiesPart extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId3");
            WordTemplateHelper.GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);

            MainDocumentPart mainDocumentPart1 = document.AddMainDocumentPart();
            WordTemplateHelper.GenerateMainDocumentPart1Content(mainDocumentPart1, model);

            DocumentSettingsPart documentSettingsPart1 = mainDocumentPart1.AddNewPart<DocumentSettingsPart>("rId3");
            WordTemplateHelper.GenerateDocumentSettingsPart1Content(documentSettingsPart1);

            ImagePart imagePart1 = mainDocumentPart1.AddNewPart<ImagePart>("image/jpeg", "rId7");
            WordTemplateHelper.GenerateImagePart1Content(imagePart1);

            ThemePart themePart1 = mainDocumentPart1.AddNewPart<ThemePart>("rId17");
            WordTemplateHelper.GenerateThemePart1Content(themePart1);

            StyleDefinitionsPart styleDefinitionsPart1 = mainDocumentPart1.AddNewPart<StyleDefinitionsPart>("rId2");
            WordTemplateHelper.GenerateStyleDefinitionsPart1Content(styleDefinitionsPart1);

            FontTablePart fontTablePart1 = mainDocumentPart1.AddNewPart<FontTablePart>("rId16");
            WordTemplateHelper.GenerateFontTablePart1Content(fontTablePart1);

            NumberingDefinitionsPart numberingDefinitionsPart1 = mainDocumentPart1.AddNewPart<NumberingDefinitionsPart>("rId1");
            WordTemplateHelper.GenerateNumberingDefinitionsPart1Content(numberingDefinitionsPart1);

            EndnotesPart endnotesPart1 = mainDocumentPart1.AddNewPart<EndnotesPart>("rId6");
            WordTemplateHelper.GenerateEndnotesPart1Content(endnotesPart1);

            FootnotesPart footnotesPart1 = mainDocumentPart1.AddNewPart<FootnotesPart>("rId5");
            WordTemplateHelper.GenerateFootnotesPart1Content(footnotesPart1);

            FooterPart footerPart1 = mainDocumentPart1.AddNewPart<FooterPart>("rId15");
            WordTemplateHelper.GenerateFooterPart1Content(footerPart1);

            WebSettingsPart webSettingsPart1 = mainDocumentPart1.AddNewPart<WebSettingsPart>("rId4");
            WordTemplateHelper.GenerateWebSettingsPart1Content(webSettingsPart1);

            mainDocumentPart1.AddHyperlinkRelationship(new System.Uri("http://www2.cse.tek.com/sws/qpe/Information/EngDevPolicy/", System.UriKind.Absolute), true ,"rId8");
            mainDocumentPart1.AddHyperlinkRelationship(new System.Uri("file:///\\\\view\\spl_cmtools_view\\route66\\software\\tools\\trace\\DefaultSRSTest.doc", System.UriKind.Absolute), true ,"rId13");
            mainDocumentPart1.AddHyperlinkRelationship(new System.Uri("file:///\\\\view\\spl_cmtools_view\\route66\\software\\tools\\trace\\NotApplicableSRSTest.doc", System.UriKind.Absolute), true ,"rId12");
            mainDocumentPart1.AddHyperlinkRelationship(new System.Uri("file:///\\\\view\\spl_cmtools_view\\route66\\software\\tools\\trace\\DefaultSRSTest.doc", System.UriKind.Absolute), true ,"rId11");
            mainDocumentPart1.AddHyperlinkRelationship(new System.Uri("http://cmweb.central.tektronix.net/web/route66/software/documents/spp", System.UriKind.Absolute), true ,"rId10");
            mainDocumentPart1.AddHyperlinkRelationship(new System.Uri("http://cmweb.central.tektronix.net/web/route66/software/documents/misc/glossary.doc", System.UriKind.Absolute), true ,"rId9");
            mainDocumentPart1.AddHyperlinkRelationship(new System.Uri("file:///\\\\view\\spl_cmtools_view\\route66\\software\\tools\\trace\\DefaultSRSTest.doc", System.UriKind.Absolute), true ,"rId14");
            CustomFilePropertiesPart customFilePropertiesPart1 = document.AddNewPart<CustomFilePropertiesPart>("rId4");
            WordTemplateHelper.GenerateCustomFilePropertiesPart1Content(customFilePropertiesPart1);

            WordTemplateHelper.SetPackageProperties(document);
        }

        // This can be used for easily inserting dynamic template creation!
        public static Body customBodyOrdering(Body body, List<OpenXmlElement> elementList, GenerateModel model)
        {
            foreach (OpenXmlElement e in elementList)
            {
                body.Append(e);
            }

            // Page break!
            new Paragraph(new Run(new Break() { Type = BreakValues.Page }));

            /*paragraph104.Append(paragraphProperties98);
            paragraph104.Append(bookmarkStart23);
            paragraph104.Append(bookmarkEnd22);
            paragraph104.Append(run384);
            paragraph104.Append(run385);

            ParagraphProperties paragraphProperties98 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId67 = new ParagraphStyleId() { Val = "Heading1" };

            paragraphProperties98.Append(paragraphStyleId67);
            BookmarkStart bookmarkStart23 = new BookmarkStart() { Name = "_TRIG_UIS3", Id = "22" };
            BookmarkEnd bookmarkEnd22 = new BookmarkEnd() { Id = "22" };*/

            // Dynamically grab requirements here!
            int icount = 0;
            for (int i = 0; i < model.areaNames.Count; i++)
            {
                body.InsertAt<Paragraph>(
                    new Paragraph(
                        new ParagraphProperties(
                            new ParagraphStyleId() { Val = "Heading1" }
                        ),
                        new Run(
                            new LastRenderedPageBreak(),
                            new Text() { Space = SpaceProcessingModeValues.Preserve, Text = model.areaNames[i] }
                        )
                    ),
                    79 + i
                );

                int jcount = icount;
                for (int j = icount; j < (jcount + model.mappings[i]); j++)
                {
                    body.InsertAt<Paragraph>(
                        new Paragraph(
                            new ParagraphProperties(
                                new ParagraphStyleId() { Val = "Rqmt" },
                                new Indentation() { Start = "0", FirstLine = "0" }
                            ),
                            new Run(
                                new RunProperties(
                                    new RunStyle() { Val = "Rqmtid" }
                                ),
                                new Text() { Text = "TRIG_UIS1" }
                            ),
                            new Run(
                                new Text() { Space = SpaceProcessingModeValues.Preserve, Text = " " }
                            ),
                            new Run(
                                new TabChar(),
                                new Text() { Text = "Test01" }
                            )
                        ),
                        79 + i + j
                    );
                    body.InsertAt<Paragraph>(
                        new Paragraph(
                            new ParagraphProperties(
                                new ParagraphStyleId() { Val = "Rqmt" },
                                new Indentation() { Start = "0", FirstLine = "0" }
                            ),
                            new Run(
                                new RunProperties(
                                    new RunStyle() { Val = "Rqmtid" }
                                ),
                                new Text() { Text = "TRIG_UIS1" }
                            ),
                            new Run(
                                new Text() { Space = SpaceProcessingModeValues.Preserve, Text = " " }
                            ),
                            new Run(
                                new TabChar(),
                                new Text() { Text = "Test01" }
                            )
                        ),
                        80 + i + j
                    );
                }
            }

            /*Paragraph paragraph107 = new Paragraph() { RsidParagraphMarkRevision = "003305C4", RsidParagraphAddition = "000537C0", RsidParagraphProperties = "000537C0", RsidRunAdditionDefault = "000537C0" };

            ParagraphProperties paragraphProperties101 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId70 = new ParagraphStyleId() { Val = "Rqmtdetails" };

            paragraphProperties101.Append(paragraphStyleId70);

            Run run389 = new Run() { RsidRunProperties = "003305C4" };
            Text text254 = new Text();
            text254.Text = "Author: Messer, Takaji,   Created: 9/14/2015,   Modified: 9/14/2015";

            run389.Append(text254);

            paragraph107.Append(paragraphProperties101);
            paragraph107.Append(run389);

            Paragraph paragraph108 = new Paragraph() { RsidParagraphMarkRevision = "003305C4", RsidParagraphAddition = "000537C0", RsidParagraphProperties = "000537C0", RsidRunAdditionDefault = "000537C0" };

            ParagraphProperties paragraphProperties102 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId71 = new ParagraphStyleId() { Val = "Rqmtplatform" };

            paragraphProperties102.Append(paragraphStyleId71);

            Run run390 = new Run() { RsidRunProperties = "003305C4" };
            Text text255 = new Text();
            text255.Text = "Platform: All";

            run390.Append(text255);

            paragraph108.Append(paragraphProperties102);
            paragraph108.Append(run390);

            Paragraph paragraph109 = new Paragraph() { RsidParagraphMarkRevision = "003305C4", RsidParagraphAddition = "000537C0", RsidParagraphProperties = "000537C0", RsidRunAdditionDefault = "000537C0" };

            ParagraphProperties paragraphProperties103 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId72 = new ParagraphStyleId() { Val = "Rqmttarget" };

            paragraphProperties103.Append(paragraphStyleId72);

            Run run391 = new Run() { RsidRunProperties = "003305C4" };
            Text text256 = new Text();
            text256.Text = "Target: Unknown";

            run391.Append(text256);

            paragraph109.Append(paragraphProperties103);
            paragraph109.Append(run391);

            Paragraph paragraph110 = new Paragraph() { RsidParagraphMarkRevision = "003305C4", RsidParagraphAddition = "000537C0", RsidParagraphProperties = "000537C0", RsidRunAdditionDefault = "000537C0" };

            ParagraphProperties paragraphProperties104 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId73 = new ParagraphStyleId() { Val = "RqmtprsId" };

            paragraphProperties104.Append(paragraphStyleId73);

            Run run392 = new Run() { RsidRunProperties = "003305C4" };
            Text text257 = new Text();
            text257.Text = "PRS ID: TBD";

            run392.Append(text257);

            paragraph110.Append(paragraphProperties104);
            paragraph110.Append(run392);

            Paragraph paragraph111 = new Paragraph() { RsidParagraphMarkRevision = "003305C4", RsidParagraphAddition = "000537C0", RsidParagraphProperties = "000537C0", RsidRunAdditionDefault = "000537C0" };

            ParagraphProperties paragraphProperties105 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId74 = new ParagraphStyleId() { Val = "RqmttestPath" };

            paragraphProperties105.Append(paragraphStyleId74);

            Run run393 = new Run() { RsidRunProperties = "003305C4" };
            Text text258 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text258.Text = "Tests: ";

            run393.Append(text258);

            Hyperlink hyperlink4 = new Hyperlink() { History = true, Id = "rId11" };
            ProofError proofError3 = new ProofError() { Type = ProofingErrorValues.SpellStart };

            Run run394 = new Run() { RsidRunProperties = "003305C4" };

            RunProperties runProperties224 = new RunProperties();
            RunStyle runStyle16 = new RunStyle() { Val = "Hyperlink" };

            runProperties224.Append(runStyle16);
            Text text259 = new Text();
            text259.Text = "TBDLink";

            run394.Append(runProperties224);
            run394.Append(text259);
            ProofError proofError4 = new ProofError() { Type = ProofingErrorValues.SpellEnd };

            hyperlink4.Append(proofError3);
            hyperlink4.Append(run394);
            hyperlink4.Append(proofError4);

            paragraph111.Append(paragraphProperties105);
            paragraph111.Append(run393);
            paragraph111.Append(hyperlink4);*/













            // Page break!
            new Paragraph(new Run(new Break() { Type = BreakValues.Page }));

            return body;
        }
    }
}
