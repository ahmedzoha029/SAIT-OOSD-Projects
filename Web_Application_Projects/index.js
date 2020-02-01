/*
DATE: Dec 08, 2019
Author: Bilal 
Author: Brian
Author: Rohit
Author: Zoha
Description: Node file to handle all server communication for the website

COURSE: CPRG-210-OSD
ASSIGNMENT: THREAD PROJECT - TERM 1
*/

//import modules
const express = require('express');
const mysql = require("mysql");
const alert = require('alert-node');
const app = express();

//uncaughtexception incase an error occurs
process.on('uncaughtException', function (err) {
    console.error(err);
    console.log("Node NOT Exiting...");
});

//stores connection in a variable
var conn = mysql.createConnection({
    host: "localhost",
    user: "Bilal",
    database: "travelexperts"
});

//Code Author: Brian
//establishes the SQL connection
conn.connect((err) => {
    if (err) throw err;
});

//using the following directories
app.use(express.static('./Views', { extensions: ['html'] }));
app.use(express.static("./"));
app.use(express.static("modules"));
app.use(express.static("images"));
app.use(express.static("js"));
app.use(express.static("css"));
app.use(express.urlencoded({ extended: true }));

//Code Author: Brian
//serves out the index page 
app.get('/', function (req, res) {
    res.sendFile(__dirname + "/views/index.html");
});

//Code Author: Brian
//Serves back the SQL PkgName column from the PACKAGES table in SQL
app.get('/getVacationPackages', function (req, res) {
    var vacationData;
    var sqlState1 = "SELECT PkgDesc FROM packages"

    conn.query(sqlState1, (err, result, fields) => {
        if (err) throw err;
        res.send(result);
    });
});

//Code Author: Zoha
app.get("/packagedata", (req, res) => {
    var data1;
    conn.query("SELECT * FROM packages WHERE `PkgStartDate`>= CURRENT_DATE", (err, result) => {
        if (err) throw err;
        res.send(result);
    });

});
//Code Author: Rohit
app.get("/agentsdata", (req, res) => {
    conn.query("SELECT AgtFirstName, AgtLastName, AgtBusPhone, AgtEmail, AgtPosition FROM agents", function (err, result) {
        if (err) throw err;
        res.send(result);
    });
});

// Code author: Bilal 
// post after clicking register Button
app.post("/post_form", (req, res) => {
    //Creates data variable to hold all the inputs
    var data = [];
    data[0] = req.body.custFirstName;
    data[1] = req.body.custLastName;
    data[2] = req.body.custAddress;
    data[3] = req.body.custCity;
    data[4] = req.body.custProv;
    data[5] = req.body.custPostal;
    data[6] = req.body.custCountry;
    data[7] = req.body.custHomePhone;
    data[8] = req.body.custBusPhone;
    data[9] = req.body.custEmail;
    data[10] = req.body.UserName;
    data[11] = req.body.userPassword;

    //Query for finding the username in the database
    var userNameQuery = "SELECT `UserName` FROM customers WHERE `UserName` = '" + req.body.UserName + "'";

    //Query for inserting current user into the database
    var sqlInsert =
        "INSERT INTO `customers`(`CustFirstName`, `CustLastName`, `CustAddress`, `CustCity`, `CustProv`,"
        + " `CustPostal`, `CustCountry`, `CustHomePhone`, `CustBusPhone`, `CustEmail`, `UserName`,`UserPassword`)"
        + " VALUES (?,?,?,?,?,?,?,?,?,?,?,?)";

    //Checks if username exists in the database
    conn.query(userNameQuery, data, (err, results, fields) => {
        if (err) throw console.log(err);
        //If username is found returns username exists
        if (results.length > 0) {
            console.log("Username already exists");
        } else {
            //if username doesn't exist, inserts the current username into the database
            conn.query(sqlInsert, data, (err, result, fields) => {
                if (err) throw err;
                //alert is displayed to the user using alert-node 
                alert("Account Registered for Username: " + req.body.UserName);
                console.log("Account Registered for Username: " + req.body.UserName);
            });
        }
    })

});

// Code author: Bilal
// Post after clicking login Button
app.post("/post_loginForm", (req, res) => {
    var UserName = req.body.uNameLogin;
    var Password = req.body.passwordLogin;

    // Query for checking if username and password exists on the database
    conn.query("SELECT * FROM customers WHERE `UserName` = ? AND `UserPassword` = ?", [UserName, Password], (err, results, fields) => {
        if (err) {
            throw err;
        } else {
            // if query returns with a matching result, it will redirect to index.html and consoles that login is successful
            if (results.length > 0) {
                console.log("login Successful");
                res.redirect("index");
            } else {
            // if query returns empty, it will console with this:
                console.log("Username not found: please register");
            }
        }
    });

});

//Code Author: Zoha
app.post("/post_Vacationform", (req, res) => {
    var data = [];
    console.log(req.body);
    data[0] = req.body.FirstName;
    data[1] = req.body.LastName;
    data[2] = req.body.PhoneNumber;
    data[3] = req.body.email;
    data[4] = req.body.PackageName;
    data[5] = req.body.PackagePrice;
    data[6] = req.body.BookingDate;


    var sql = "INSERT INTO `tblpackagebooking`(`cfname`, `clname`, `cphone`, `cemail`, `cpackagename`, `cpackageprice`, `bkgdate`) VALUES (?,?,?,?,?,?,?)";

    conn.query(sql, data, (err, result, fields) => {
        if (err) throw err;
        console.log(result);
    });
});
//Code Author: Brian
app.listen(8000, err => {
    if (err) throw err;
    console.log("Server started on port 8000");
});

//Code Author: Rohit
app.post("/send_form", (req, res) => {
    var data = [];
    data[0] = req.body.Full_Name;
    data[1] = req.body.Phone;
    data[2] = req.body.City;
    data[3] = req.body.EmailId;
    data[4] = req.body.Reason;
    var sql =
        "INSERT INTO contact (Full_Name, Phone, City, EmailId, Reason) VALUES (?,?,?,?,?)";
    conn.query(sql, data, (err, result, fields) => {
        if (err) throw err;
    });
});