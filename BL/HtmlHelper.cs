using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BL
{
    public static class HtmlHelper
    {
        public static List<string> GetRawLinesFromHtml(string html)
        {
            string rawLine;
            StringReader sr = new StringReader(html);
            List<string> rawLines = new List<string>();
            while ((rawLine = sr.ReadLine()) != null)
            {
                if (rawLine != "")
                    rawLines.Add(rawLine.Trim());
            }

            return rawLines;
        }

        public static List<string> GetImportantLines(List<string> rawLines, string stringToStartRecording, string stringToStopRecording)
        {
            List<string> selectedLines = new List<string>();
            bool startRecording = false;
            for (int i = 0; i < rawLines.Count; i++)
            {
                if (rawLines[i].Contains(stringToStartRecording) && !startRecording)
                    startRecording = true;

                if (rawLines[i].Contains(stringToStopRecording) && startRecording)
                {
                    break;
                }

                if (startRecording)
                    selectedLines.Add(rawLines[i]);
            }

            return selectedLines;
        }
        public static string ExtractString(string source, string startSequence, string endSequence, bool keepStartSequence)
        {
            string result = "";
            if (keepStartSequence)
                if (endSequence != "")
                    result = source.Substring(source.IndexOf(startSequence), source.IndexOf(endSequence, source.IndexOf(startSequence)) - source.IndexOf(startSequence));
                else
                    result = source.Substring(source.IndexOf(startSequence));
            else
                if (endSequence != "")
                result = source.Substring(source.IndexOf(startSequence) + startSequence.Length, source.IndexOf(endSequence, source.IndexOf(startSequence)) - (source.IndexOf(startSequence) + startSequence.Length));
            else
                result = source.Substring(source.IndexOf(startSequence) + startSequence.Length);

            return result;
        }
    }
}
