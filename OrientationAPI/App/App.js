﻿var app = angular.module("OrientationAPI", ["ngRoute", "angularMoment"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "/app/partials/home.html",
            controller: "HomeController"
        })
        .when("/employees",
        {
            templateUrl: "/app/partials/Employees/Employees.html",
            controller: "EmployeesController"
        })
        .when("/CreateEmployee",
        {
            templateUrl: "/app/partials/Employees/CreateEmployee.html",
            controller: "EmployeesController"
        })
        .when("/employee-details/:id",
        {
            templateUrl: "/app/partials/Employees/EmployeeDetails.html",
            controller: "Employees/EmployeeDetailsController"

        })
        .when("/Training",
        {
            templateUrl: "/app/partials/trainingPrograms/index.html",
            controller: "TrainingPrograms/IndexController"
        })
        .when("/Training/Add",
        {
            templateUrl: "/app/partials/trainingPrograms/add.html"
        })
        .when("/training/:id", {
            templateUrl: "/app/partials/trainingPrograms/edit.html"
        })
        .when("/Departments",
        {
            templateUrl: "/app/partials/Departments.html",
            controller: "DepartmentController"
        })
        .when("/DepartmentsAdd",
        {
            templateUrl: "/app/partials/DepartmentsAdd.html",
            controller: "DepartmentController"
        })

        .otherwise('/');
}]);