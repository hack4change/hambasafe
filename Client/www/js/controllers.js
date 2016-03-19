angular.module('starter.controllers', [])

  .controller('DashCtrl', function ($scope) {
  })

  .controller('ChatsCtrl', function ($scope, Chats) {
    // With the new view caching in Ionic, Controllers are only called
    // when they are recreated or on app start, instead of every page change.
    // To listen for when this page is active (for example, to refresh data),
    // listen for the $ionicView.enter event:
    //
    //$scope.$on('$ionicView.enter', function(e) {
    //});

    $scope.chats = Chats.all();
    $scope.remove = function (chat) {
      Chats.remove(chat);
    };
  })

  .controller('ChatDetailCtrl', function ($scope, $stateParams, Chats) {
    $scope.chat = Chats.get($stateParams.chatId);
  })

  .controller('LandingCtrl', function ($scope, $stateParams, Facebook, LocalStorage, $location) {
    $scope.getLoginStatus = function () {
      Facebook.getLoginStatus(function (response) {
        if (response.status === 'connected') {
          $scope.loggedIn = true;
          $location.path('registration');
        } else {
          $scope.loggedIn = false;
        }
      });
    };

    $scope.fbLogin = function () {
      // From now on you can use the Facebook service just as Facebook api says
      Facebook.login(function (response) {
        // Do something with response.
        console.log(response);
        LocalStorage.facebookAuth = response;
        $location.path('registration');
      });
    };
  })

  .controller('RegistrationCtrl', function ($scope, $stateParams, Facebook, LocalStorage) {
    $scope.fbMe = function () {
      // From now on you can use the Facebook service just as Facebook api says
      Facebook.api('/me', function (response) {
        $scope.user = response;
        console.log($scope.user);
      });
    };

    $scope.doRegister = function (valid) {
      $scope.submitted = true;

      if (!$scope.loginData.password) {
        valid = false;
      } else if ($scope.loginData.password.length < 7) {
        valid = false;
      } else {
        $scope.passwordError = null;
      }

      $scope.updatePasswordError();

      if (valid) {
        LoadingSvc.show();
        Users.signup({}, $scope.loginData
          , function (user) {
            LocalStorage.user = user;
            $scope.authentication.user = user;
            $location.path('valuations');
            LoadingSvc.hide();
          }
          , function (errorResponse) {
            console.log('error signing user up');
            $scope.error = errorResponse.data.message;
            LoadingSvc.hide();
          });
      } else {
        $scope.error = 'Please fill in all required fields';
      }
    }
  })

  .controller('TermsCtrl', function ($scope) {

  })

  .controller('AboutUsCtrl', function ($scope) {

  })

  .controller('AccountCtrl', function ($scope) {
    $scope.settings = {
      enableFriends: true
    }
  })
  .controller('LatestCtrl', function ($scope, $location) {



    $scope.goCreateAnEvent = function () {
      $location.path('registration');
    }

    $scope.goHambaSafe = function() {
      $location.path('eventdetail');
    } 
  })
  .controller('EventDetailCtrl', function ($scope, $location) {
      
      $scope.eventData = {
          attending: false,
          location: "CAPE TOWN, RONDEBOSH",
          title: "Cycling in numbers",
          type: "CYCLE",
          distance: "5KM",
          level: "NOVICE",
          date: "20 November 2015",
          summary: "This is a 'Facebook' styled Card. The header is created from a Thumbnail List item,        the content is from a card-body consisting of an image and paragraph text. The footer consists of tabs, icons aligned left, within the card-footer.",
          numberOfAttendees: "4"
      }

      $scope.init = function() {
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
 
  })
  .controller('HomeCtrl', function ($scope, eventFactory) {
    var t = eventFactory.get();

    $scope.events = [];

    for (var i = 0; i < 50; i++) {
      var event = {label: "Test " + i};
      $scope.events.push(event)
    }
  }).controller('CreateCtrl', function ($scope) {
    //init
    (function(){
    })()
  }).controller('SearchCtrl', function ($scope) {
    //init
    (function(){
    })()
    $scope.searchEvents = function(){
    
    }
    $scope.eventType = ["Walk", "Run", "Cycle"];
    $scope.typeSelected = $scope.eventType[0];

    /*
     * if given group is the selected group, deselect it
     * else, select the given group
     */
    $scope.toggleGroup = function(group) {
      if ($scope.isGroupShown(group)) {
        $scope.shownGroup = null;
      } else {
        $scope.shownGroup = group;
      }
    };
    $scope.isGroupShown = function(group) {
      return $scope.shownGroup === group;
    };
    /*
     * if given group is the selected group, deselect it
     * else, select the given group
     */
    $scope.toggleSelection = function(selected) {
      $scope.typeSelected = selected;
    };

  })
