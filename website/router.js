const express = require("express");
const app = express();
const port = 80;
const ip = "127.0.0.1";

app.get("/", (req, res) => res.sendFile(__dirname + "/pages/index.html"));
app.use(express.static(__dirname + "/pages"));

app.listen(port, ip, () => console.log("Listening on " + ip + ":" + port));
