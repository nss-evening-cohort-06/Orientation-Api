﻿var app = angular.module("OrientationAPI", ["ngRoute", "angularMoment"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "/app/partials/home.html",
            controller: "HomeController"
        })
        .when("/employees",
        {
            templateUrl: "/app/partials/Employees.html",
            controller: "EmployeesController"
        })
        .when("/CreateEmployee",
        {
            templateUrl: "/app/partials/CreateEmployee.html",
            controller: "EmployeesController"
        })
        .when("/employee-details/:id",
        {
            templateUrl: "/app/partials/EmployeeDetails.html",
            controller: "EmployeesController"

        })
        .when("/Training",
        {
            templateUrl: "/app/partials/trainingprograms.html",
            controller: "TrainingProgramsController"
        })
        .when("/TrainingAdd",
        {
            templateUrl: "/app/partials/TrainingProgramsAdd.html"
        })
        .when("/Departments",
        {
            templateUrl: "/app/partials/Departments.html",
            controller: "DepartmentController"
        })

        .otherwise('/');
}]);