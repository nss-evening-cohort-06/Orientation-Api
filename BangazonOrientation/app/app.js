﻿var app = angular.module("StillNotQuiteHuman", ['ngRoute']);

app.config([
    '$routeProvider', function ($routeProvider) {
        $routeProvider
            .when("/",
            {
                templateUrl: '/app/partials/index.html',
                controller: 'HomeController'
            })
            .when("/computers",
            {
                templateUrl: '/app/partials/computers.html',
                controller: 'ComputersController'
            })
            .when("/computers/new",
            {
                templateUrl: '/app/partials/new_computer.html',
                controller: 'NewComputersController'
            })
            .when("/computers/:id",
            {
                templateUrl: '/app/partials/computers_detail.html',
                controller: 'ComputersDetailController'
            })
            .when("/computers/:id/delete",
            {
                templateUrl: '/app/partials/computers_delete.html',
                controller: 'ComputersDeleteController'
            })
            .when("/departments",
            {
                templateUrl: '/app/partials/departments.html',
                controller: 'DepartmentsController'

            })
            .when("/employees",
            {
                templateUrl: '/app/partials/employees.html',
                controller: 'EmployeeController'
            })
            .when("/employees/new",
            {
                templateUrl: '/app/partials/new_employee.html',
                controller: 'NewEmployeeController'
            })
            .when("/employees/:id",
            {
                templateUrl: '/app/partials/employee_details.html',
                controller: 'EmployeeDetailController'
            })
            .when("/departments/new",
            {
                templateUrl: '/app/partials/new_department.html',
                controller: 'NewDepartmentsController'
            })
            .when("/departments/:id",
            {
                templateUrl: '/app/partials/departments_detail.html',
                controller: 'DepartmentsDetailController'
            })
            .when("/training" || "/training?new=true",
            {
                templateUrl: '/app/partials/trainingProgram.html',
                controller: 'TrainingProgramController'
            })
            .otherwise({
                templateUrl: '/app/partials/index.html',
                controller: 'HomeController'
            });
    }
]);