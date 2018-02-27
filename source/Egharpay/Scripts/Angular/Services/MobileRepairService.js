﻿(function () {
    'use strict';

    angular
        .module('Egharpay')
        .factory('MobileRepairService', MobileRepairService);

    MobileRepairService.$inject = ['$http'];

    function MobileRepairService($http) {
        var service = {
            createMobileRepairRequest: createMobileRepairRequest,
            retrieveMobileRepairOrders: retrieveMobileRepairOrders,
            retrieveMobileRepairOrdersByMobile: retrieveMobileRepairOrdersByMobile,
            markAsCompleted: markAsCompleted,
            markAsCancelled:markAsCancelled,
            deleteMobileRepairRequest: deleteMobileRepairRequest
        };

        return service;

        function createMobileRepairRequest(model) {
            var url = "/MobileRepair/Create",
                data = {
                    model: model
                };
            return $http.post(url, data);
        }

        //function retrieveMobileRepairOrders() {
        //    var url = "/MobileRepair/RetrieveMobileRepairOrders/" + mobileNumber;
        //    return $http.get(url, data);
        //}
      
        function retrieveMobileRepairOrdersByMobile(mobileNumber, otp) {
            var url = "/MobileRepair/RetrieveMobileRepairOrdersByMobile/" + mobileNumber + "/" + otp;
            return $http.get(url);
        }

        function deleteMobileRepairRequest(mobileRepairId, mobileNumber, otp) {
            var url = "/MobileRepair/DeleteMobileRepairRequest",
                 data = {
                     mobileRepairId: mobileRepairId,
                     mobileNumber: mobileNumber,
                     otp: otp
                 };
            return $http.post(url, data);
        }

        function retrieveMobileRepairOrders(Paging, OrderBy) {
            var url = "/MobileRepair/List",
            data = {
                paging: Paging,
                orderBy: new Array(OrderBy)
            };
            return $http.post(url, data);
        }

        function markAsCompleted(mobileRepairId) {
            var url = "/MobileRepair/MarkAsCompleted",
            data = {
                mobileRepairId: mobileRepairId,
                mobileRepairStateId: mobileRepairStateId
            };
            return $http.post(url, data);
        }

        function markAsCancelled(mobileRepairId) {
            var url = "/MobileRepair/MarkAsCompleted",
            data = {
                mobileRepairId: mobileRepairId,
                mobileRepairStateId: mobileRepairStateId
            };
            return $http.post(url, data);
        }

    }
})();