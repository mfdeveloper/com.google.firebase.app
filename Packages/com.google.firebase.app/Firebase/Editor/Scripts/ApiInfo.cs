/*
 * Copyright 2016 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using UnityEditor;
using UnityEngine;
using UnityEngine.Localization;

namespace Firebase.Editor {

  internal class ApiInfo {
    public Texture2D Image { get; protected set; }
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }

    // Links
    public virtual string ApiReference { get; set; }

    // Guides
    public virtual string GuideButton { get; set; }
    public virtual string GuideLink { get; set; }
    
    // LocalizedString with table/key references to localize error and warning messages
    private static LocalizedString MessagesLocalizedString => new LocalizedString() { 
        TableReference = "FirebaseMessages"
    };

    // Images (not the 2x versions) should be pulled from the Android Studio Firebase plugin.
    public ApiInfo(string imagePath) {
      Image = (Texture2D) EditorGUIUtility.Load(
        "Firebase/fb_" + imagePath + (EditorGUIUtility.isProSkin ? "_dark" : "") + ".png");
    }

    public static ApiInfo Analytics() {
      MessagesLocalizedString.TableEntryReference = "AnalyticsName";
      var analyticsName = MessagesLocalizedString.GetLocalizedString();
        
      MessagesLocalizedString.TableEntryReference = "AnalyticsDescription";
      var analyticsDescription = MessagesLocalizedString.GetLocalizedString();
        
      MessagesLocalizedString.TableEntryReference = "AnalyticsGuideSummary";
      var analyticsGuideSummary = MessagesLocalizedString.GetLocalizedString();
        
      return new ApiInfo("analytics")
      {
        Name = analyticsName,
        Description = analyticsDescription,
        ApiReference = Link.FIREBASE_ANALYTICS_API_REFERENCE,
        GuideButton = analyticsGuideSummary,
        GuideLink = Link.FIREBASE_ANALYTICS_GUIDE
      };
    }

    public static ApiInfo Auth() {
      MessagesLocalizedString.TableEntryReference = "AuthName";
      var authName = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "AuthDescription";
      var authDescription = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "AuthGuideSummary";
      var authGuideSummary = MessagesLocalizedString.GetLocalizedString();
        
      return new ApiInfo("auth")
      {
        Name = authName,
        Description = authDescription,
        ApiReference = Link.FIREBASE_AUTH_API_REFERENCE,
        GuideButton = authGuideSummary,
        GuideLink = Link.FIREBASE_AUTH_GUIDE
      };
    }

    public static ApiInfo CloudMessaging() {
      MessagesLocalizedString.TableEntryReference = "CloudMessagingName";
      var cloudMessagingName = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "CloudMessagingDescription";
      var cloudMessagingDescription = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "CloudMessagingGuideSummary";
      var cloudMessagingGuideSummary = MessagesLocalizedString.GetLocalizedString();
        
      return new ApiInfo("cloud_messaging")
      {
        Name = cloudMessagingName,
        Description = cloudMessagingDescription,
        ApiReference = Link.FIREBASE_MESSAGING_API_REFERENCE,
        GuideButton = cloudMessagingGuideSummary,
        GuideLink = Link.FIREBASE_MESSAGING_GUIDE
      };
    }

    public static ApiInfo Crashlytics() {
      MessagesLocalizedString.TableEntryReference = "CrashlyticsName";
      var crashlyticsName = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "CrashlyticsDescription";
      var crashlyticsDescription = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "CrashlyticsGuideSummary";
      var crashlyticsGuideSummary = MessagesLocalizedString.GetLocalizedString();
      
      return new ApiInfo("crashlytics")
      {
        Name = crashlyticsName,
        Description = crashlyticsDescription,
        ApiReference = Link.FIREBASE_CRASHLYTICS_API_REFERENCE,
        GuideButton = crashlyticsGuideSummary,
        GuideLink = Link.FIREBASE_CRASHLYTICS_GUIDE
      };
    }

    public static ApiInfo Database() {
      MessagesLocalizedString.TableEntryReference = "DatabaseName";
      var databaseName = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "DatabaseDescription";
      var databaseDescription = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "DatabaseGuideSummary";
      var databaseGuideSummary = MessagesLocalizedString.GetLocalizedString();

      return new ApiInfo("database")
      {
        Name = databaseName,
        Description = databaseDescription,
        ApiReference = Link.FIREBASE_DATABASE_API_REFERENCE,
        GuideButton = databaseGuideSummary,
        GuideLink = Link.FIREBASE_DATABASE_GUIDE
      };
    }

    public static ApiInfo DynamicLinks() {
      MessagesLocalizedString.TableEntryReference = "DynamicLinksName";
      var dynamicLinksName = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "DynamicLinksDescription";
      var dynamicLinksDescription = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "DynamicLinksGuideSummary";
      var dynamicLinksGuideSummary = MessagesLocalizedString.GetLocalizedString();
      
      return new ApiInfo("dynamic_links")
      {
        Name = dynamicLinksName,
        Description = dynamicLinksDescription,
        ApiReference = Link.FIREBASE_DYNAMIC_LINKS_API_REFERENCE,
        GuideButton = dynamicLinksGuideSummary,
        GuideLink = Link.FIREBASE_DYNAMIC_LINKS_GUIDE
      };
    }

    public static ApiInfo Functions() {
      MessagesLocalizedString.TableEntryReference = "FunctionsName";
      var functionsName = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "FunctionsDescription";
      var functionsDescription = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "FunctionsGuideSummary";
      var functionsGuideSummary = MessagesLocalizedString.GetLocalizedString();
      
      return new ApiInfo("functions")
      {
        Name = functionsName,
        Description = functionsDescription,
        ApiReference = Link.FIREBASE_FUNCTIONS_API_REFERENCE,
        GuideButton = functionsGuideSummary,
        GuideLink = Link.FIREBASE_FUNCTIONS_GUIDE
      };
    }

    public static ApiInfo RemoteConfig() {
      MessagesLocalizedString.TableEntryReference = "RemoteConfigName";
      var remoteConfigName = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "RemoteConfigDescription";
      var remoteConfigDescription = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "RemoteConfigGuideSummary";
      var remoteConfigGuideSummary = MessagesLocalizedString.GetLocalizedString();
      
      return new ApiInfo("config")
      {
        Name = remoteConfigName,
        Description = remoteConfigDescription,
        ApiReference = Link.FIREBASE_CONFIG_API_REFERENCE,
        GuideButton = remoteConfigGuideSummary,
        GuideLink = Link.FIREBASE_CONFIG_GUIDE
      };
    }

    public static ApiInfo Storage() {
      MessagesLocalizedString.TableEntryReference = "StorageName";
      var storageName = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "StorageDescription";
      var storageDescription = MessagesLocalizedString.GetLocalizedString();
      
      MessagesLocalizedString.TableEntryReference = "StorageGuideSummary";
      var storageGuideSummary = MessagesLocalizedString.GetLocalizedString();
      
      return new ApiInfo("storage")
      {
        Name = storageName,
        Description = storageDescription,
        ApiReference = Link.FIREBASE_STORAGE_API_REFERENCE,
        GuideButton = storageGuideSummary,
        GuideLink = Link.FIREBASE_STORAGE_GUIDE
      };
    }
  }

}  // Firebase.Editor
