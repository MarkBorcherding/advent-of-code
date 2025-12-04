namespace AdventOfCode2024.Days.Day09;

public class Day09 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var diskMap = input.Trim();
        var blocks = ExpandDiskMap(diskMap);
        CompactPart1(blocks);
        return CalculateChecksum(blocks).ToString();
    }

    public string SolvePart2(string input)
    {
        var diskMap = input.Trim();
        var blocks = ExpandDiskMap(diskMap);
        CompactPart2(blocks, diskMap);
        return CalculateChecksum(blocks).ToString();
    }

    private List<int> ExpandDiskMap(string diskMap)
    {
        var blocks = new List<int>();
        int fileId = 0;

        for (int i = 0; i < diskMap.Length; i++)
        {
            int length = diskMap[i] - '0';
            if (i % 2 == 0) // File
            {
                for (int j = 0; j < length; j++)
                    blocks.Add(fileId);
                fileId++;
            }
            else // Free space
            {
                for (int j = 0; j < length; j++)
                    blocks.Add(-1); // -1 represents free space
            }
        }

        return blocks;
    }

    private void CompactPart1(List<int> blocks)
    {
        int left = 0;
        int right = blocks.Count - 1;

        while (left < right)
        {
            // Find leftmost free space
            while (left < right && blocks[left] != -1)
                left++;

            // Find rightmost file block
            while (left < right && blocks[right] == -1)
                right--;

            if (left < right)
            {
                blocks[left] = blocks[right];
                blocks[right] = -1;
                left++;
                right--;
            }
        }
    }

    private void CompactPart2(List<int> blocks, string diskMap)
    {
        // Build file info: (startPos, length) for each file ID
        var files = new List<(int start, int length)>();
        int pos = 0;
        for (int i = 0; i < diskMap.Length; i++)
        {
            int length = diskMap[i] - '0';
            if (i % 2 == 0) // File
            {
                files.Add((pos, length));
            }
            pos += length;
        }

        // Process files from highest ID to lowest
        for (int fileId = files.Count - 1; fileId >= 0; fileId--)
        {
            var (fileStart, fileLen) = files[fileId];
            if (fileLen == 0) continue;

            // Find leftmost span of free space that can fit this file
            int freeStart = -1;
            int freeLen = 0;

            for (int i = 0; i < fileStart; i++)
            {
                if (blocks[i] == -1)
                {
                    if (freeStart == -1) freeStart = i;
                    freeLen++;
                    if (freeLen >= fileLen)
                        break;
                }
                else
                {
                    freeStart = -1;
                    freeLen = 0;
                }
            }

            if (freeLen >= fileLen && freeStart != -1)
            {
                // Move the file
                for (int i = 0; i < fileLen; i++)
                {
                    blocks[freeStart + i] = fileId;
                    blocks[fileStart + i] = -1;
                }
            }
        }
    }

    private long CalculateChecksum(List<int> blocks)
    {
        long checksum = 0;
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i] != -1)
                checksum += (long)i * blocks[i];
        }
        return checksum;
    }
}
