using System;
using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

class Program
{
    static void Main()
    {
        // Replace with the path to your PDF file
        string pdfFilePath = @"resumeAC.pdf";

        // Extract text from the PDF
        string extractedText = ExtractTextFromPdf(pdfFilePath);

        // // Print the extracted text to the console
        // Console.WriteLine("Extracted Text:\n" + extractedText);

        // Replace with the word you want to find
        string targetWord = "ARITRA";
        if (extractedText.Contains(targetWord, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"The word '{targetWord}' was found.");
            // Console.WriteLine(extractedText.IndexOf(targetWord));

            int start = extractedText.IndexOf(targetWord);
            start += 6; // bcuz aritra is of size 6
            start += 1; // for space after aritra
            string name = "";
            while(extractedText[start] != ' ') {
                name += extractedText[start];
                start++;
            }
            Console.WriteLine("surename  = "  + name);
            
        } else {
            Console.WriteLine($"The word '{targetWord}' was NOT found.");
        }
    }

    static string ExtractTextFromPdf(string pdfFilePath)
    {
        // Create a StringBuilder to store the extracted text
        StringBuilder textBuilder = new StringBuilder();

        // Open the PDF document
        using (PdfDocument pdfDocument = new PdfDocument(new PdfReader(pdfFilePath)))
        {
            // Iterate through the pages of the PDF
            for (int pageNumber = 1; pageNumber <= pdfDocument.GetNumberOfPages(); pageNumber++)
            {
                // Extract text from the current page
                string pageText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNumber));

                // Append the text to the StringBuilder
                textBuilder.Append(pageText);
            }
        }

        // Return the extracted text as a string
        return textBuilder.ToString();
    }
}
