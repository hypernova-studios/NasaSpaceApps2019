const express = require("express");
const app = express();
const port = 80;

app.get("/", (req, res) => res.sendFile(__dirname + "\\pages\\index.html"));
app.use(express.static("pages"));

app.listen(port, () => console.log("Listening on port " + port));