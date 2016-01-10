'use restrict';

functionalDashboardApp.controller('monitorController',
    ['$scope', '$rootScope', '$exceptionHandler', 'SLTTracking', 'Events',
        function ($scope, $rootScope, $exceptionHandler, SLTTracking, Events) {

            $scope.slttracking = [];
            $scope.events = [];

            $scope.sortField = 'Institution';
            $scope.sortField2 = 'DateStart';
            $scope.sortField3 = 'DateStart';
            $scope.sortField4 = 'BreachTime';
            $scope.reverse = true;
            $scope.reverse2 = true;
            $scope.reverse3 = true;
            $scope.reverse4 = true;

            $scope.startDate = '09/01/2015';
            var current = new Date();
            $scope.endDate = (current.getMonth() + 1) + '/' + current.getDate() + '/' + current.getFullYear();


            $scope.init = function () {
                var promise = SLTTracking.query();
                promise.$promise.then(function (payload) {
                    $scope.slttracking = payload;
                }),

                promise = Events.query({ start: $scope.startDate, end: $scope.endDate });
                promise.$promise.then(function (payload) {
                    $scope.events = payload;
                    $scope.fileErrorCount = 0;
                    $scope.wsErrorCount = 0;
                    angular.forEach($scope.events, function (value, key) {
                        // Get file name from absolute path
                        if (value.URI != null && value.URI != 'NoURI') {
                            //value.URI = value.URI.replace(/^.*(\\|\/|\:)/, ''); // -> works, but performance worse
                            value.URI = value.URI.split('\\').pop().split('/').pop();
                        }
                        else {
                            value.URI = '';
                        }
                        // calculate file error count used for pagination
                        if (value.FileErrors > 0) {
                            $scope.fileErrorCount += 1;
                        }

                        // calculate webservice error count used for pagination
                        if (value.WSErrors > 0) {
                            $scope.wsErrorCount += 1;
                        }
                    });
                }),
                function (error) {
                    if (error.data.InnerException != null) {
                        $exceptionHandler(error.data.InnerException, error.status + ', ' + error.statusText);
                    }
                    else if (error.data.ExceptionMessage != null) {
                        $exceptionHandler(error.data.ExceptionMessage, error.status + ', ' + error.statusText);
                    }
                    else if (error.data.MessageDetail != null) {
                        $exceptionHandler(error.data.MessageDetail, error.status + ', ' + error.statusText);
                    }
                    else {
                        $exceptionHandler(error.data, error.status + ', ' + error.statusText);
                    }
                }
            };
        }
    ]);


