// JavaScript
// Использовала отладчик JS https://www.programiz.com/javascript/online-compiler/ (терминал)

// Kashperko Vasilisa Sergeevna
// 0100101101100001011100110110100001110000011001010111001001101011011011110010000001010110011000010111001101101001011011000110100101110011011010110110000100100000010100110110010101110010011001110110010101100101011101100110111001100001
// S2FzaHBlcmtvIFZhc2lsaXNrYSBTZXJnZWV2bmE=

const input1 ='Kashperko Vasilisa Sergeevna';
const input2 = 'This is a text about my lab. I wanted to do this task on JS, but I barely know how to use it correctly with files. That is why I did it on C#, but also we can check our algorithm in JS, writing our message manually. Goodbye!';

const buffer1 = new Buffer.from(input1);
const buffer2 = new Buffer.from(input2);

console.log(input1 + '\n');

function asciiToBin(input)
    {
    var result = "";
    var count = 0;
    for (var i = 0; i < input.length; i++)
    {
         var bin = input[i].toString(2);
      result += Array(8 - bin.length + 1).join("0") + bin;
    } 
    return result;
  }
  
function check(input)
    {
        var count = 0;
    for (var i = 0; i < input.length; i++)
    {
         count++;
    } 
    return count/8;
    }

const binary = asciiToBin(buffer1).toString();
console.log(binary);
console.log('Check: '+check(binary) + '\n');

const base64Converted = buffer1.toString('base64');
console.log(base64Converted);

const original = buffer1.toString('ascii');
console.log(original+ '\n');

console.log(input2 + '\n');

const binaryText = asciiToBin(buffer2).toString();
console.log(binaryText);
console.log('Check: ' + check(binaryText) + '\n');

const base64ConvertedText = buffer2.toString('base64');
console.log(base64ConvertedText);

const originalText = buffer2.toString('ascii');
console.log(originalText+ '\n');