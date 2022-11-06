// JavaScript
// Использовала отладчик JS https://www.programiz.com/javascript/online-compiler/ (терминал)

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
    
function XORFun(string1, string2)
    {
        var resultXOR = "";
        for (var i = 0; i < string1.length; i++)
        {
            if (string1[i] == string2[i])
            {
                resultXOR += "0";
            }
            else
            {
                resultXOR += "1";
            }
        }
        return resultXOR;
    }
    
const input1 ='Kashperko';
const buffer1 = new Buffer.from(input1);
const binary1 = asciiToBin(buffer1).toString();

const input2 ='Vasiliska';
const buffer2 = new Buffer.from(input2);
const binary2 = asciiToBin(buffer2).toString();

console.log(binary1 + '\n');
console.log(binary2 + '\n');

var XORResultBin1 =  XORFun(binary1,binary2);

console.log('XOR имени и фамилии  ASCII binary: ' + XORResultBin1 + '\n');

console.log(check(XORResultBin1) + '\n');

const base64Converted1 = buffer1.toString('base64');
console.log(base64Converted1);

const base64Converted2 = buffer2.toString('base64');
console.log(base64Converted2  + '\n');

var base64Bin1 = asciiToBin(base64Converted1).toString();
var base64Bin2 = asciiToBin(base64Converted2).toString();
var XORResultBin2 =  XORFun(base64Bin1,base64Bin2);

console.log('XOR имени и фамилии base64 binary: ' + XORResultBin2 + '\n');

var XORStarASCIIBin = XORFun(XORResultBin1, binary2);
var XORStarBse64Bin = XORFun(XORResultBin2, base64Bin2);

console.log('Задание со звездочкой ascii: ' + XORStarASCIIBin);