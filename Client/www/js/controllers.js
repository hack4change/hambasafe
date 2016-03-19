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

  .controller('LandingCtrl', function ($scope, $stateParams, Facebook, LocalStorage, $location, $state) {
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
    $scope.goHome = function () {
      $state.go('tab.home');
    };
    $scope.goLatest = function () {
      $state.go('tab.latest');
    };
    $scope.goCreate = function () {
      $state.go('tab.create');
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

    $scope.doRegister = function(valid) {
      $scope.submitted = true;

      if(!$scope.loginData.password) {
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
    };
  }).controller('HomeCtrl', function ($scope) {

  }).controller('LatestCtrl', function ($scope) {

  }).controller('CreateCtrl', function ($scope) {

  });
