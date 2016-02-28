'use restrict';

functionalDashboardApp.controller('cubicwsController',
    ['$scope', '$rootScope', '$exceptionHandler', 'Events', 
function ($scope, $rootScope, $exceptionHandler, Events) {

    $scope.cubicws_ppass = [];
    $scope.cubicws_upass = [];
    $scope.cubicws_stream = [];
    $rootScope.eligibilityRequests = [];

    $scope.sortField = 'Institution';
    $scope.sortField2 = 'DateStart';
    $scope.sortField3 = 'DateStart';
    $scope.sortField4 = 'DatetimeProcessed';
    $scope.reverse = true;
    $scope.reverse2 = true;
    $scope.reverse3 = true;
    $scope.reverse4 = true;


    $scope.startDate = '09/01/2015';
    var current = new Date();
    $scope.endDate = (current.getMonth() + 1) + '/' + current.getDate() + '/' + current.getFullYear();


    $scope.init = function () {
        var promise = Events.queryOnFilesOrWs({ start: $scope.startDate, end: $scope.endDate, sequence: 4 });
        promise.$promise.then(function (payload) {
            $scope.cubicws_ppass = payload;
        }),
        promise = Events.queryOnFilesOrWs({ start: $scope.startDate, end: $scope.endDate, sequence: 5 });
        promise.$promise.then(function (payload) {
            $scope.cubicws_upass = payload;
        }),
        promise = Events.queryOnFilesOrWs({ start: $scope.startDate, end: $scope.endDate, sequence: 6 });
        promise.$promise.then(function (payload) {
            $scope.cubicws_stream = payload;
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

    $scope.getEvent = function (id) {
        $rootScope.event = {};
        var keepGoing = true;
        angular.forEach($scope.cubicws_stream, function (value, key) {
            if (keepGoing) {
                if (value.ID == id) {
                    $rootScope.Program = value.Program;
                    //$rootScope.xmldata = x2js.xml_str2json(value.XmlData).rawData;
                    $rootScope.xmldata = xmlParser.xml_str2json(value.XmlData).rawData;
                    keepGoing = false;
                }
            }
        }
     )
    };

    $rootScope.getUserDetail = function (institutionID, guid) {
        var keepGoing = true;
        angular.forEach($scope.cubicws_stream, function (value, key) {
            if (keepGoing) {
                if (value.InstitutionID == institutionID && (value.GUID == guid || value.UniqueParticipantId == guid)) {
                    $rootScope.Program = value.Program;
                    $rootScope.Institution = value.Institution;
                    $rootScope.InstitutionID = value.InstitutionID;
                    $rootScope.NCSName = value.NCSName;
                    $rootScope.OrganizationId = value.OrganizationId;
                    $rootScope.GUID = value.GUID;
                    $rootScope.TSID = value.TSID;
                    keepGoing = false;
                }
            }
            if (value.InstitutionID == institutionID && (value.GUID == guid || value.UniqueParticipantId == guid)) {
                var eligibility = {};
                eligibility.EligDate = value.EligDate;
                eligibility.Elig = value.Elig;
                eligibility.DatetimeProcessed = value.DateStart;
                eligibility.Status = value.Status;
                $rootScope.eligibilityRequests.push(eligibility);
            }
        })
    };
}
    ]);


