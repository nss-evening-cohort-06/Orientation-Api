var app = angular.module("StillNotQuiteHuman", ["ngRoute"]);

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
            .when("/employees",
            {
                templateUrl: '/app/partials/employees.html',
                controller: 'EmployeeController'
            })
            .when("/training"
            {
                templateUrl: '/app/partials/trainingProgram.html',
                controller: 'TrainingProgramController'
            });
    }
]);