﻿app.controller("EmployeeDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $scope.hasComputer = true;
        $scope.edit = false;
        $scope.employeeTrainings = [];

        $http.get(`/api/employees/${$routeParams.id}/computer`).then((result) => {
            if (result.data.ComputerID === undefined)
                return $scope.hasComputer = false;
            $scope.employee = result.data;
        });

        $http.get(`/api/employees/training/${$routeParams.id}`).then((results) => {
            $scope.employeeTrainings = results.data;
        });

        $http.get('/api/computers/available').then((results) => {
            $scope.availableComputers = results.data;
        });

        $http.get('/api/employees/training').then((results) => {
            $scope.trainings = results.data;
        });

        $scope.back = () => {
            $location.path(`/employees`);
        };

        $scope.cancelEdit = (id) => {
            $location.path(`/employees`);
        }

        $scope.edits = () => {
            $scope.edit = true;
        }

        $scope.checkTraining = (title) => {
            var returnValue = false;
            $scope.employeeTrainings.forEach(function(training) {
                if (title === training.TrainingTitle) {
                    returnValue = true;
                    return;
                }
            });
            return returnValue;
        };

        $scope.trainingDate = (trainingdate) => {
            var returnValue = true;
            var training = new Date(trainingdate);
            var today = new Date();

            if (training <= today) {
                returnValue = false;
            }
            return returnValue;
        }

        $scope.saveEdits = (employee, selectedtraining) => {
            console.log(employee);
            console.log(selectedtraining);
        }
    }
]);