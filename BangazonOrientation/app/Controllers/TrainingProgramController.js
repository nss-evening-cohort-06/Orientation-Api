app.controller("TrainingProgramController", ["$location", "$scope", "$http", "$window", "$q",
    function ($location, $scope, $http, $window, $q) {

        $scope.temp = {};

        const GetEmployeesForTraining = (id) => {
            var EmployeeArray = [];
            return $q((resolve, reject) => {
                $http.get(`/api/trainingprogram/${id}/employeelist`).then(function (result) {
                    EmployeeArray = result.data;
                    resolve(EmployeeArray);
                }).catch((err) => {
                    reject(err);
                });
            });
        };

        const grabEmployees = (i, id) => {
            GetEmployeesForTraining(id).then((result) => {
                $scope.results[i].Employees = result;
            }).catch((err) => {
                console.log("error in GetEmployeesForTraining", err);
            });
        };

        $scope.results = [];

        $http.get("/api/trainingprogram/").then(function (result) {
            
            $scope.results = result.data;  

            for (var i = 0, len = $scope.results.length; i < len; i++) {
                startdate = $scope.results[i].StartDate;
                $scope.results[i].StartDate = moment(startdate).format('MMMM Do YYYY, h:mm:ss a');
                $scope.results[i].EndDate = moment($scope.results[i].EndDate).format('MMMM Do YYYY, h:mm:ss a');
                $scope.results[i].isDisabled = moment(startdate).isAfter(new Date()) ? false : true;
                grabEmployees(i, $scope.results[i].TrainingProgramID);
            }
            $scope.trainingPrograms = $scope.results; 
            console.log($scope.results);
        });

        $scope.DeleteTraining = (course) => {

            $http.delete(`/api/trainingprogram/${course.TrainingProgramID}/delete`).then(function (result) {
                console.log(result);
            });

            $window.location.reload();
        }

        $scope.CreateTraining = (newTraining) => {
            //$http.post(`/api/trainingprogram/create`, newTraining).then(function () {
            //    console.log(result);
            //});

            //$window.location.reload();

            console.log(newTraining);

        }

        $scope.EditTraining = () => {

        }





    }
]);