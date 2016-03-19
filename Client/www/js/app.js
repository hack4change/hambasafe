// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
// 'starter.services' is found in services.js
// 'starter.controllers' is found in controllers.js
angular.module('starter', ['ui.router', 'ionic', 'starter.controllers', 'starter.services', 'facebook', 'ngResource'])

  .constant('config', {
    //baseServiceURL: "http://hambasafedev.azurewebsites.net"
    baseServiceURL: "http://api.emguidance.com/openmed/api"
  })

  .run(function ($ionicPlatform) {
    $ionicPlatform.ready(function () {
      // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
      // for form inputs)
      if (window.cordova && window.cordova.plugins && window.cordova.plugins.Keyboard) {
        cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
        cordova.plugins.Keyboard.disableScroll(true);

      }
      if (window.StatusBar) {
        // org.apache.cordova.statusbar required
        StatusBar.styleDefault();
      }

      //$facebookProvider.setAppId(289482390688)


    });
  })

  .config(function ($stateProvider, $urlRouterProvider, FacebookProvider, $httpProvider) {

    $httpProvider.defaults.useXDomain = true;
    FacebookProvider.init('289482390688');

    // Ionic uses AngularUI Router which uses the concept of states
    // Learn more here: https://github.com/angular-ui/ui-router
    // Set up the various states which the app can be in.
    // Each state's controller can be found in controllers.js
    $stateProvider

    // setup an abstract state for the tabs directive
      .state('landing', {
        url: '/landing',
        templateUrl: 'templates/landing.html',
        controller: 'LandingCtrl'
      })
      .state('registration', {
        url: '/registration',
        templateUrl: 'templates/registration.html',
        controller: 'RegistrationCtrl'
      })
      .state('home', {
        url: '/home',
        templateUrl: 'templates/home.html',
        controller: 'HomeCtrl'
      })

      .state('terms', {
        url: '/terms',
        templateUrl: 'templates/terms.html',
        controller: 'TermsCtrl'
      })

      .state('tab', {
        url: '/tab',
        abstract: true,
        templateUrl: 'templates/tabs.html'
      })

      .state('latest', {
        url: '/latest',
       // views: {
       //   'tab-latest': {
            templateUrl: 'templates/latest.html',
            controller: 'LatestCtrl'
        //  }
        //}
      })

      .state('create', {
        url: '/create',
        templateUrl: 'templates/create.html',
        controller: 'CreateCtrl'
      })

      .state('tab.dash', {
        url: '/dash',
        views: {
          'tab-dash': {
            templateUrl: 'templates/tab-dash.html',
            controller: 'DashCtrl'
          }
        }
      })

      .state('tab.chats', {
        url: '/chats',
        views: {
          'tab-chats': {
            templateUrl: 'templates/tab-chats.html',
            controller: 'ChatsCtrl'
          }
        }
      })

      .state('tab.chat-detail', {
        url: '/chats/:chatId',
        views: {
          'tab-chats': {
            templateUrl: 'templates/chat-detail.html',
            controller: 'ChatDetailCtrl'
          }
        }
      })

      .state('tab.account', {
        url: '/account',
        views: {
          'tab-account': {
            templateUrl: 'templates/tab-account.html',
            controller: 'AccountCtrl'
          }
        }
      })

      // if none of the above states are matched, use this as the fallback
      $urlRouterProvider.otherwise('/landing');
  });
