var app = angular.module("OrientationAPI", ["ngRoute", "angularMoment"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "/app/partials/home.html",
            controller: "HomeController"
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

        .otherwise('/');
}]);