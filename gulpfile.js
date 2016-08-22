/*
  This file in the main entry point for defining Gulp tasks and using Gulp plugins.
  Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/
"use strict";

var gulp = require("gulp");

let exec = require('child_process').exec;
let spawn = require('child_process').spawn;
let Buffer = require('buffer').Buffer; // buffer and decode lite-server output

gulp.task('run', function () {
	let dotnet = spawn('dotnet', ['run']);
	dotnet.stdout.on('data', function(data){
		let buffer = new Buffer(data, 'hex');
		console.log(buffer.toString('utf8'));
	})	
})

gulp.task("default", function() {
  // place code for your default task here
});
