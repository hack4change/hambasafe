starterControllers.controller('EventDetailCtrl', function ($scope, $location, EventFactory) {

      // $scope.eventData = {
      //     attending: false,
      //     location: "CAPE TOWN, RONDEBOSH",
      //     title: "Cycling in numbers",
      //     type: "CYCLE",
      //     distance: "5KM",
      //     level: "NOVICE",
      //     date: "20 November 2015",
      //     summary: "This is a 'Facebook' styled Card. The header is created from a Thumbnail List item,        the content is from a card-body consisting of an image and paragraph text. The footer consists of tabs, icons aligned left, within the card-footer.",
      //     numberOfAttendees: "4"
      // }
      $scope.eventData = {};
      $scope.init = function() {

      EventFactory.getEvent({id: 3}
       , function (event) {
         $scope.eventData = event;
         console.log(event);
       }
       , function (error) {

       });

        $scope.attendingDescription = "JOIN";
        if ($scope.eventData.attending) {
          $scope.attendingDescription = "CANCEL"
        }
      }

      $scope.doAttend = function() {
        $scope.eventData.attending = !$scope.eventData.attending;
        $scope.attendingDescription = "JOIN";
        if ($scope.eventData.attending) {
          $scope.attendingDescription = "CANCEL"
        }
      }

  });
