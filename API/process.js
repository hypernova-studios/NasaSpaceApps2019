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
		if (parseInt(data[i][j]) !== 99999 && parseInt(data[i][j]) > 9000)
		{
			const y = Math.floor(i / 3600 * width);
			const x = Math.floor(j / 3600 * width);
			const dimensionsx = 10*1165;
			const dimensionsy = 10*582;
			
			fs.writeFileSync("./fetch.sh", "gdal_translate -of GTiff -outsize 700 700 -srcwin " + x + " " + y + " " + dimensionsx + " " + dimensionsy + " thing.xml file" + x + "and" + y + ".tif");

			console.log(x + "," + y + "," + dimensionsx + "," + dimensionsy + " on " + j + "," + i);
			shell.exec("./fetch.sh");
			//console.log(data.length);
			
			obj[x + "," + y] = data[i][j];
		}

fs.writeFileSync("./pop.json", JSON.stringify(obj));

process.stdin.read();