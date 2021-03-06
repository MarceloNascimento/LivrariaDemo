﻿(function () {
    'use strict';

    var app = angular.module("app");


    app.directive('validateEmail', function () {
        var EMAIL_REGEXP = /^[_a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/;
        return {
            link: function (scope, elm) {
                elm.on("keyup", function () {
                    var isMatchRegex = EMAIL_REGEXP.test(elm.val());
                    if (isMatchRegex && elm.hasClass('has-error') || elm.val() === '') {
                        elm.removeClass('has-error');
                    } else if (isMatchRegex === false && !elm.hasClass('has-error')) {
                        elm.addClass('has-error');
                    }
                });
            }
        }
    });

    app.directive('fileModel', ['$parse', function ($parse) {
       return {
               restrict: 'A',
               link: function(scope, element, attrs) {
                  var model = $parse(attrs.fileModel);
                  var modelSetter = model.assign;
                  element.bind('change', function(){
                      scope.$apply(function () {                         
                        modelSetter(scope, element[0].files[0]);
                     });
                  });
               }
            };
         }]);

   
  

})();


