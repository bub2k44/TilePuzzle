<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Headers: access");
header("Access-Control-Allow-Methods: POST, GET");
header("Access-Control-Allow-Credentials: true");
header("Content-Type: text/plain");

//We thank DontMissTheFlight for the making of this script
include( "../includes/db_admin.php" );

//variables from the user/program/game
$Init = $_POST["Init"];
$Score = $_POST["Score"];
$Secret = $_POST["Secret"];

if($Secret != "kIkxPvHc2uK3DWFBzzPSDNEwAlOAc7wH")
{
	die("You are not authorized. Nice try hacker...");
}

//Connections
// Pull the connection from the database connection string
$conn = $pdo;


//SQL Command
$sql = "INSERT INTO [dbo].[PnSHigh]([Initials],[Score]) VALUES (:Init,:Score)";
// Prepare the SQL query statement
$stmt = $conn->prepare( $sql );

// Bind parameters
$stmt->bindParam( ':Init', $Init, PDO::PARAM_STR );
$stmt->bindParam( ':Score', $Score, PDO::PARAM_INT );

// Perform the SQL query
$stmt->execute();

// set response code - 200 OK
http_response_code(200);

// Notify the calling AJAX function of completion
echo "Input Recieved";

// Clear and close the connection
$conn = null;

?>