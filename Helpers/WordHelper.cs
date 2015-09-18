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
        public static void exportToWord(SRSCRUDModel model)
        {
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
            response.AddHeader("Content-Disposition", "attachment; filename=" + model.srs.Filename + ".docx;");
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
        public static void CreateParts(WordprocessingDocument document, SRSCRUDModel model)
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
        public static Body customBodyOrdering(Body body, List<OpenXmlElement> elementList, SRSCRUDModel model)
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

                    body.InsertAt<Paragraph>(
                        new Paragraph(
                            new ParagraphProperties(
                                new ParagraphStyleId() { Val = "Rqmtdetails" }
                            ),
                            new Run(
                                new Text() { Text = "Author: Messer, Takaji,   Created: 9/14/2015,   Modified: 9/14/2015" }
                            ) { RsidRunProperties = "003305C4" }
                        ) { RsidParagraphMarkRevision = "003305C4", RsidParagraphAddition = "000537C0", RsidParagraphProperties = "000537C0", RsidRunAdditionDefault = "000537C0" },
                        81 + i + j
                    );

                    body.InsertAt<Paragraph>(
                        new Paragraph(
                            new ParagraphProperties(
                                new ParagraphStyleId() { Val = "Rqmtplatform" }
                            ),
                            new Run(
                                new Text() { Text = "Platform: All" }
                            ) { RsidRunProperties = "003305C4" }
                        ) { RsidParagraphMarkRevision = "003305C4", RsidParagraphAddition = "000537C0", RsidParagraphProperties = "000537C0", RsidRunAdditionDefault = "000537C0" },
                        82 + i + j
                    );

                    body.InsertAt<Paragraph>(
                        new Paragraph(
                            new ParagraphProperties(
                                new ParagraphStyleId() { Val = "Rqmttarget" }
                            ),
                            new Run(
                                new Text() { Text = "Target: Unknown" }
                            ) { RsidRunProperties = "003305C4" }
                        ) { RsidParagraphMarkRevision = "003305C4", RsidParagraphAddition = "000537C0", RsidParagraphProperties = "000537C0", RsidRunAdditionDefault = "000537C0" },
                        83 + i + j
                    );

                    body.InsertAt<Paragraph>(
                        new Paragraph(
                            new ParagraphProperties(
                                new ParagraphStyleId() { Val = "RqmtprsId" }
                            ),
                            new Run(
                                new Text() { Text = "PRS ID: TBD" }
                            ) { RsidRunProperties = "003305C4" }
                        ) { RsidParagraphMarkRevision = "003305C4", RsidParagraphAddition = "000537C0", RsidParagraphProperties = "000537C0", RsidRunAdditionDefault = "000537C0" },
                        84 + i + j
                    );

                    body.InsertAt<Paragraph>(
                        new Paragraph(
                            new ParagraphProperties(
                                new ParagraphStyleId() { Val = "RqmttestPath" }
                            ),
                            new Run(
                                new Text() { Text = "Tests: ", Space = SpaceProcessingModeValues.Preserve }
                            ) { RsidRunProperties = "003305C4" },
                            new Hyperlink(
                                new ProofError() { Type = ProofingErrorValues.SpellStart },
                                new Run(
                                    new RunProperties(
                                        new RunStyle() { Val = "Hyperlink" }
                                    ),
                                    new Text() { Text = "TBDLink" }
                                ) { RsidRunProperties = "003305C4" },
                                new ProofError() { Type = ProofingErrorValues.SpellEnd }
                            ) { History = true, Id = "rId11" }
                        ) { RsidParagraphMarkRevision = "003305C4", RsidParagraphAddition = "000537C0", RsidParagraphProperties = "000537C0", RsidRunAdditionDefault = "000537C0" },
                        85 + i + j
                    );
                }
            }

            // Page break!
            new Paragraph(new Run(new Break() { Type = BreakValues.Page }));

            return body;
        }
    }
}
