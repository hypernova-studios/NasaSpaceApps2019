const fs = require("fs");

const data = fs
	.readFileSync("./population.csv")
	.toString()
	.split("\n")
	.map(x =>
		x.split(",")
	);

console.log("Coords: " + data.length + "x" + data[0].length);
let str = "";

for (let i = 0; i < data.length; i += 1)
{
	for (let j = 0; j < data[i].length; j += 1)
		if (parseInt(data[i][j]) !== 99999 && parseInt(data[i][j]) > 50)
			str += "*";
		else
			str += " ";
	str += "\r\n";
}

fs.writeFileSync("./out.txt", str);

process.stdin.read();
