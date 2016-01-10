'use restrict';

var file_ppass_list = [];
functionalDashboardApp.controller('filesController',
    ['$scope', '$rootScope', '$exceptionHandler', 'Events',
        function ($scope, $rootScope, $exceptionHandler, Events) {


            $scope.file_ppass = [];
            $scope.file_upass = [];
            $scope.file_stream = [];
            
            $scope.sortField = 'Institution';
            $scope.sortField2 = 'DateStart';
            $scope.sortField3 = 'DateStart';
            $scope.sortField4 = 'DateStart';
            $scope.sortField5 = 'DateStart';
            $scope.reverse = true;
            $scope.reverse2 = true;
            $scope.reverse3 = true;
            $scope.reverse4 = true;
            $scope.reverse5 = true;

            $scope.startDate = '09/01/2015';
            var current = new Date();
            $scope.endDate = (current.getMonth() + 1) + '/' + current.getDate() + '/' + current.getFullYear();


            $scope.init = function () {
                if (file_ppass_list.length > 0) {
                    $scope.file_ppass = file_ppass_list;
                    return;
                }
                var promise = Events.queryOnFilesOrWs({ start: $scope.startDate, end: $scope.endDate, sequence: 1 });
                promise.$promise.then(function (payload) {
                    $scope.file_ppass = payload;
                    file_ppass_list = payload;
                    angular.forEach($scope.file_ppass, function (value, key) {
                        if (value.Uri != null && value.Uri != 'NoURI') {
                            value.Uri = value.Uri.split('\\').pop().split('/').pop();
                        }
                        else {
                            value.Uri = '';
                        }
                    });

                }),
                promise = Events.queryOnFilesOrWs({ start: $scope.startDate, end: $scope.endDate, sequence: 2 });
                promise.$promise.then(function (payload) {
                    $scope.file_upass = payload;
                }),

                promise = Events.queryOnFilesOrWs({ start: $scope.startDate, end: $scope.endDate, sequence: 3 });
                promise.$promise.then(function (payload) {
                    $scope.file_stream = payload;
                    angular.forEach($scope.file_stream, function (value, key) {
                        if (value.Uri != null && value.Uri != 'NoURI') {
                            value.Uri = value.Uri.split('\\').pop().split('/').pop();
                        }
                        else {
                            value.Uri = '';
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

            $scope.getFileDetail = function (institutionID, uri) {
                $rootScope.fileDetail = [];
                $rootScope.TotalErrors = 0;
                // sequence = 7 -> file detail per institution
                var promise = Events.queryOnFilesOrWs({
                    start: $scope.startDate, end: $scope.endDate, sequence: 7,
                    institutionID: institutionID, uri: uri
                })
                promise.$promise.then(function (payload) {
                    $rootScope.fileDetail = payload;
                    var keepGoing = true;
                    angular.forEach($rootScope.fileDetail, function (value, key) {
                        if (keepGoing) {
                            $rootScope.NCSName = value.NCSName;
                            $rootScope.OrganizationId = value.OrganizationId;
                            $rootScope.NCSCustomerAssignedID = value.NCSCustomerAssignedID;
                            $rootScope.DateStart = value.DateStart;
                            $rootScope.FileName = uri;
                            $rootScope.Directory = value.Uri.substr(0, value.Uri.length - uri.length);
                            keepGoing = false;
                        }

                        if (value.Errors > 0) {
                            $rootScope.TotalErrors += value.Errors;
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

            $scope.getXmlData = function (id) {
                $rootScope.xmlData = {};
                var keepGoing = true;

                angular.forEach($rootScope.fileDetail, function (value, key) {
                    if (keepGoing) {
                        if (value.ID == id) {
                            $rootScope.xmlData = x2js.xml_str2json(value.XmlData).rawData;
                            keepGoing = false;
                        }
                    };
                })
            };

            $rootScope.getInstitutionDetail = function (id) {

                if (file_ppass_list.length == 0) {
                    var promise = Events.queryOnFilesOrWs({ start: $scope.startDate, end: $scope.endDate, sequence: 1 });
                    promise.$promise.then(function (payload) {
                        $scope.file_ppass = payload;
                        file_ppass_list = payload;
                        setFilePpass(id);
                    })
                }
                else {
                    $scope.file_ppass = file_ppass_list;
                    setFilePpass(id);
                }
            };

            function setFilePpass(id) {
                $scope.file_ppass = file_ppass_list;
                angular.forEach($scope.file_ppass, function (value, key) {
                    if (value.Uri != null && value.Uri != 'NoURI') {
                        value.Uri = value.Uri.split('\\').pop().split('/').pop();
                    }
                    else {
                        value.Uri = '';
                    }
                });
                var keepGoing = true;
                $rootScope.institution_file_detail = [];
                angular.forEach($scope.file_ppass, function (value, key) {
                    if (keepGoing) {
                        if (value.InstitutionID != null && value.InstitutionID == id) {
                            $rootScope.Program = value.Program;
                            $rootScope.NCSName = value.NCSName;
                            $rootScope.OrganizationId = value.OrganizationId;
                            $rootScope.NCSCustomerAssignedID = value.NCSCustomerAssignedID;

                            $rootScope.IufRequests = value.IufRequests;
                            $rootScope.FufRequests = value.FufRequests;
                            $rootScope.FcfRequests = value.FcfRequests;
                            $rootScope.IcfRequests = value.IcfRequests;
                            $rootScope.TotalErrors = value.TotalErrors;


                            keepGoing = false;
                        }
                    }
                    if (value.InstitutionID != null && value.InstitutionID == id) {
                        $rootScope.institution_file_detail.push(value);
                    }
                });
            }

        }
    ]);

