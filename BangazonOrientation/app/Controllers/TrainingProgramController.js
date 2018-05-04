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
                $scope.results[i].StartDate = moment(startdate).format('MMMM D YYYY, h:mm:ss a');
                $scope.results[i].EndDate = moment($scope.results[i].EndDate).format('MMMM D YYYY, h:mm:ss a');
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
        };

        $scope.CreateTraining = (newTraining) => {
            $scope.created = true;

            newTraining.StartDate = convertDateTime(newTraining.StartDate);
            newTraining.EndDate = convertDateTime(newTraining.EndDate);

            console.log(newTraining);

            $http.post(`/api/trainingprogram/create`, JSON.stringify(newTraining)).then(function (result) {
                console.log(result);
            });

            $window.location.reload();

        };

        const convertDateTime = (dt) => {
            var x = moment(dt, 'MMMM D YYYY, h:mm:ss a').format();
            var y = x.split("-");
            y.pop();
            return y.join("-");
        };

        $scope.EditTraining = (editedCourse) => {
            $scope.edited = true;
            var id = editedCourse.TrainingProgramID;

            delete editedCourse.$$hashKey;
            delete editedCourse.Employees;
            delete editedCourse.isDisabled;

            editedCourse.StartDate = convertDateTime(editedCourse.StartDate);
            editedCourse.EndDate = convertDateTime(editedCourse.EndDate);

            console.log(editedCourse);

            $http.put(`/api/trainingprogram/${id}/edit`, JSON.stringify(editedCourse)).then(function (result) {
                console.log(result);
            });

            editedCourse.StartDate = moment(editedCourse.StartDate).format('MMMM D YYYY, h:mm:ss a');
            editedCourse.EndDate = moment(editedCourse.EndDate).format('MMMM D YYYY, h:mm:ss a');
        };

        $scope.undisable = () => {
            $scope.edited = false;
            $scope.created = false;

        };

        $scope.undisable = () => {
            $scope.edited = false;
        };

        $scope.showThis = true;
        $scope.showThat = true;

        $scope.showAll = () => {
            $scope.showThis = true;
            $scope.showThat = true;
        };

        $scope.showPast = () => {
            $scope.showThis = false;
            $scope.showThat = true;
        };

        $scope.showFuture = () => {
            $scope.showThis = true;
            $scope.showThat = false;
        };
    }
]);