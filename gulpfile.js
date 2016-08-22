/*
  This file in the main entry point for defining Gulp tasks and using Gulp plugins.
  Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/
"use strict";

var gulp = require("gulp");
var $ = require('gulp-load-plugins')({ lazy: true });

let exec = require('child_process').exec;
let spawn = require('child_process').spawn;
let Buffer = require('buffer').Buffer; // buffer and decode process output

gulp.task('run', function () {
	// 'dotnet run' auomatically runs 'build'
	let dotnet = spawn('dotnet', ['run']);
	dotnet.stdout.pipe(process.stdout);
})

gulp.task('build', function () {
	let dotnet = spawn('dotnet', ['build']);
	dotnet.stdout.pipe(process.stdout);
})

gulp.task('restore', function () {
	let dotnet = spawn('dotnet', ['restore']);
	dotnet.stdout.pipe(process.stdout);	
})

gulp.task('help', $.taskListing);
gulp.task("default", ['help']);
