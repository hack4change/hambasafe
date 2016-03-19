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
    console.log('Here');
  })

  .controller('AccountCtrl', function ($scope) {
    $scope.settings = {
      enableFriends: true
    }
  })

  .controller('HomeCtrl', function ($scope, eventFactory) {
    var t = eventFactory.get();

    $scope.events = [];

    for (var i = 0; i < 50; i++) {
      var event = {label: "Test " + i};
      $scope.events.push(event)
    }


    $scope.goCreateAnEvent = function () {
      $location.path('registration');
    }

    $scope.goHambaSafe = function() {
      $location.path('tab.home');
    } 
  }).controller('CreateCtrl', function ($scope) {
    //init
    (function(){
      $scope.createModel = {
        eventTitle    : null,
        startTime     : null,
        finishTime    : null,
        startDate     : null, 
        description   : null,
        maxTime       : null,
        availabilty   : null,
        eventType     : null,
        pace          : null, 
        distance      : null,
        meetingPoint  : null,
      };
    })()
    $scope.createEvent() = function(){
       
    }
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
