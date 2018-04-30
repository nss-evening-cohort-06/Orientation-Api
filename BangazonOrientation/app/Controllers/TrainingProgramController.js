app.controller("TrainingProgramController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $http.get("/api/trainingprogram/").then(function (result) {
            $scope.trainingPrograms = result.data;
        });

        $scope.trainingProgramDetails = (id) => {

            $location.path(`/api/trainingprogram/show/${id}`);

        };
/*
        $http.get("/api/trainingprogram/").then(function (result) {
            $scope.trainingPrograms = result.data;
        });

*/

        $http.get("/api/trainingprogram/${id}/edit").then(function (result) {
            $scope.trainingPrograms = result.data;
        });

    }
]);