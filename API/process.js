const fs = require("fs");
const shell = require("shelljs");
const width = 4194304; //magic number

const data = fs
	.readFileSync("./population.csv")
	.toString()
	.split("\n")
	.map(x =>
		x.split(",")
	);

console.log("Coords: " + data.length + "x" + data[0].length);
let obj = {};

for (let i = 0; i < data.length; i += 1)
	for (let j = 0; j < data[i].length; j += 1)
		if (parseInt(data[i][j]) !== 99999 && parseInt(data[i][j]) > 200)
		{
			const y = Math.floor(i / data.length * width);
			const x = Math.floor(j / 2 / data[0].length * width);
			const dimensions = Math.floor(4194304 / data.length);
			
			fs.writeFileSync("./fetch.sh", "gdal_translate -of GTiff -outsize 700 700 -srcwin " + x + " " + y + " " + dimensions + " " + dimensions + " thing.xml file" + x + "and" + y + ".tif");
			shell.exec("./fetch.sh");
			console.log(x + "," + y + "," + dimensions + "," + dimensions + " on " + j + "," + i);
			
			obj[x + "," + y] = data[i][j];
		}

fs.writeFileSync("./out.txt", str);

process.stdin.read();