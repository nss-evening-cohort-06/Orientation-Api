app.controller("TrainingProgramsDetailController", ["$scope", "$http", "$location", "$routeParams", "TrainingProgramService",
    function ($scope, $http, $location, $routeParams, TrainingProgramService) {


        const getTrainingById = function () {
            TrainingProgramService.getTrainingById($routeParams.id).then(function (results) {
                console.log(results);
                $scope.program = results;
            }).catch(function (err) {
                console.log("error in updateTraining in controller", err);
            })
        }();

        const updateTraining = function () {
            TrainingProgramService.updateTraining($scope.program).then(function (results) {
                console.log(results);
            }).catch(function (err) {
                console.log("error in updateTraining in controller", err);
            })
        }

        $scope.navigateToList = function () {
            $location.path(`/Training`);
        }


        $scope.submitUpdatedProgram = function () {
            updateTraining();
            $scope.navigateToList();
        }

        $scope.toggleEditMode = function () {
            $scope.editMode = !$scope.editMode;
        }

    }
]);



