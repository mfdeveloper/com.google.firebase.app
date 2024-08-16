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


namespace Firebase.Editor {
    
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization;
using GooglePlayServices;

[InitializeOnLoad]
internal class AndroidSettingsChecker : AssetPostprocessor {
    static bool checkedVersion = false;
    const int MinSupportedAndroidApiLevel = 14;
    
    private static LocalizedString MessagesLocalizedString => new LocalizedString()
    {
        TableReference = "FirebaseMessages"
    };

    static AndroidSettingsChecker() {
        
        if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android) {
            CheckMinimumAndroidVersion();
        }
    }

    // Check the minimum android sdk and ensure its >= MinSupportedAndroidApiLevel (usually 14).
    private static void CheckMinimumAndroidVersion() {
      if (!checkedVersion) {
        checkedVersion = true;
        var detectedApiLevel = UnityCompat.GetAndroidMinSDKVersion();
        bool isBelowMinSupported = detectedApiLevel < MinSupportedAndroidApiLevel;

        if (isBelowMinSupported) {

          var reportParameters = new[] {
            new KeyValuePair<string, string>(
              "androidApiLevel",
                detectedApiLevel.ToString()
            )
          };
        
          var fix = ShowAndroidVersionDialog();

          if (fix) {
            var fixedVersion = FixAndroidVersion();

            if (fixedVersion) {
              Measurement.analytics.Report(
                reportUrl: "android/incompatibleapilevel/apply",
                parameters: reportParameters,
                reportName: "Incompatible Android API Level: Apply"
              );
            }
        
            return;
          }

          Measurement.analytics.Report(
            reportUrl: "android/incompatibleapilevel/cancel",
            parameters: reportParameters,
            reportName: "Incompatible Android API Level: Cancel"
          );
        }
      }
    }
        
    private static bool ShowAndroidVersionDialog() {
        MessagesLocalizedString.TableEntryReference = "AndroidSdkVersionMismatch";
      
        var versionMisMatchMsg = MessagesLocalizedString.GetLocalizedString(
            new {
                minApiLevel = MinSupportedAndroidApiLevel
            }
        );
      
        if (!string.IsNullOrEmpty(versionMisMatchMsg)) { 
          Debug.LogError(versionMisMatchMsg);
        }
      
        MessagesLocalizedString.TableEntryReference = "AndroidSdkVersionMismatchSummary";
        var versionMisMatchSummaryMsg = MessagesLocalizedString.GetLocalizedString();
      
        MessagesLocalizedString.TableEntryReference = "AndroidSdkVersionChange";
        var versionChangeMsg = MessagesLocalizedString.GetLocalizedString();
      
        MessagesLocalizedString.TableEntryReference = "Yes";
        var yesMsg = MessagesLocalizedString.GetLocalizedString();
      
        MessagesLocalizedString.TableEntryReference = "No";
        var noMsg = MessagesLocalizedString.GetLocalizedString();

        var dialogMsg = $"{versionMisMatchMsg}\n\n{versionChangeMsg}";
      
        return EditorUtility.DisplayDialog(
            title: versionMisMatchSummaryMsg,
            message: dialogMsg,
            ok: yesMsg,
            cancel: noMsg
        );
    }

    private static bool FixAndroidVersion()
    {
        bool setSdkVersion = UnityCompat.SetAndroidMinSDKVersion(MinSupportedAndroidApiLevel);
        if (!setSdkVersion) {
            // Get the highest installed SDK version to see whether it's
            // suitable.
            if (UnityCompat.FindNewestInstalledAndroidSDKVersion() 
                >= MinSupportedAndroidApiLevel) {
                // Set the mode to "auto" to use the latest installed
                // version.
                setSdkVersion = UnityCompat.SetAndroidMinSDKVersion(-1);
            }
        }

        if (!setSdkVersion) {
          MessagesLocalizedString.TableEntryReference = "AndroidMinSdkVersionSetFailure";
      
          var versionSetFailureMsg = MessagesLocalizedString.GetLocalizedString(
              new {
                  minApiLevel = MinSupportedAndroidApiLevel
              }
          );

          if (!string.IsNullOrEmpty(versionSetFailureMsg)) { 
              Debug.LogError(versionSetFailureMsg);
          }

          return false;
        }
        return true;
    }
}
}
