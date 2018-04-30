app.controller("TrainingPrograms/EditController", ["$scope", "$http", "$location", "$routeParams", "TrainingProgramService", "ModelTransferService",
    function ($scope, $http, $location, $routeParams, TrainingProgramService, ModelTransferService) {

        const updateTraining = function () {
            TrainingProgramService.updateTraining($scope.program).then(function (results) {
                if (results.status === 200) {
                    $location.path(`/Training`)
                }
            }).catch(function (err) {
                console.log("error in updateTraining in controller", err);
            })
        }

        const getTrainingById = function () {
            TrainingProgramService.getTrainingById($routeParams.id).then(function (results) {
                console.log(results);
                results.StartDate = new Date(results.StartDate);
                results.EndDate = new Date(results.EndDate);
                $scope.program = results;
                $scope.programName = angular.copy($scope.program.Name)
            }).catch(function (err) {
                console.log("error in updateTraining in controller", err);
            })
        };

        getTrainingById();

        $scope.navigateToList = function () {
            $location.path(`/Training`);
        }

        $scope.submitUpdatedProgram = function () {
            updateTraining();
        }

        $scope.toggleEditMode = function () {
            $scope.formDisabled = !$scope.formDisabled;
            getTrainingById();
        }       




    }
]);