app.controller("TrainingProgramsController", ["$scope", "$http", "$location", "TrainingProgramService", "ModelTransferService",
    function ($scope, $http, $location, TrainingProgramService, ModelTransferService) {

        //get upcoming project
        var getUpcomingTraining = function() {
            TrainingProgramService.getAllUpcomingPrograms().then(function(results) {
                $scope.programs = results;
            }).catch(function (error) {
                console.log("error in getUpcomingTraining", error);
            });
        }();

        const addTraining = function () {
            TrainingProgramService.addTraining($scope.program).then(function (results) {
                console.log(results);
            }).catch(function (err) {
                console.log("error in addtraining in controller", err); 
            })
        }

        const updateTraining = function () {
            TrainingProgramService.updateTraining($scope.program).then(function (results) {
                console.log(results);
            }).catch(function (err) {
                console.log("error in updateTraining in controller", err); 
            })
        }

        $scope.navigateToAdd = function () {
            var currentLocation = $location.path();
            $location.path(`/TrainingAdd`);
        }

        $scope.navigateToList = function () {
            $location.path(`/Training`);
        }


        $scope.submitNewProgram = function () {
            addTraining();
            $scope.navigateToList(); 
        }

        $scope.programDetail = function (programId) {
            $location.path(`/training/${programId}`);
        }
    }
]);