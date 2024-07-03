# Burrows-Wheeler Algorithm Project

This project implements the Burrows-Wheeler transform, Move-to-Front encoding, and Huffman encoding in C# to compress and decompress text files efficiently.

## Overview

The Burrows-Wheeler transform rearranges characters in the input text to enhance compression by clustering similar characters together. Move-to-Front encoding and Huffman coding further reduce the size of the transformed text.

### Steps in Detail

### [1] Burrows-Wheeler Transform

#### a. Transform

The Burrows-Wheeler transform prepares the text for compression without actually reducing its size. It operates in three main steps:

1. **Generate Suffixes**: Create N suffixes of the input string, assuming it's cyclic.
   
2. **Sort Suffixes**: Arrange these N suffixes in ascending order.
   
3. **Output Transformation**: The transformed string (`t[]`) is the last column in the sorted suffix list, preceded by the index of the original string.

#### b. Inverse Transform

To recover the original message from its Burrows-Wheeler transform:
- If suffix j appears in row i of the sorted order, use `next[i]` to find where suffix j+1 appears.

### [2] Move-to-Front Encoding

#### a. Encoding

Move-to-Front encoding converts the clustered text from the Burrows-Wheeler transform into a stream of integers by:
   
1. **Maintaining Order**: Keeping an ordered list of legal symbols.
   
2. **Symbol Position**: Reading each symbol from the input and printing its position.
   
3. **Symbol Movement**: Moving the symbol to the front of the list.

#### b. Decoding

To decode the Move-to-Front encoded integers:
   
1. **Initialize List**: Start with an ordered list of 256 characters (extended ASCII).
   
2. **Integer Translation**: Read each integer and print the corresponding character.
   
3. **Character Movement**: Move the character to the front of the list after each decoding step.

### [3] Huffman Coding

Huffman coding compresses the stream of integers from Move-to-Front encoding using variable-length codewords:
- Common integers have shorter codewords, and rare integers have longer codewords.

## Usage

To compress a text file:
1. Perform Burrows-Wheeler transform.
2. Apply Move-to-Front encoding.
3. Use Huffman coding for final compression.

To decompress:
1. Reverse Huffman coding.
2. Decode Move-to-Front.
3. Inverse Burrows-Wheeler transform.

### Implementation

The algorithms are implemented in C# and can be run from the command line using the provided scripts or integrated into C# applications. Ensure .NET Framework or .NET Core is installed.

### Example

```bash
# Compile and run C# programs as per your setup
