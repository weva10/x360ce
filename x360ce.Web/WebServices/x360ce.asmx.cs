﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.Objects;
using System.Linq.Expressions;
using System.Web.Security;
using x360ce.Engine.Data;
using x360ce.Engine;
using x360ce.App;

namespace x360ce.Web.WebServices
{
    /// <summary>
    /// Summary description for x360ce
    /// </summary>
    [WebService(Namespace = "http://x360ce.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class x360ce : System.Web.Services.WebService, IWebService
    {


        /// <summary>
        /// Save controller settings.
        /// </summary>
        /// <param name="s">Setting object which contains information about DirectInput device and file/game name it is used for.</param>
        /// <param name="ps">PAD settings which contains maping between DirectInput device and virtual XBox controller.</param>
        /// <returns>Status of operation. Empty if success.</returns>
        [WebMethod(EnableSession = true, Description = "Save controller settings.")]
        public string SaveSetting(Setting s, PadSetting ps)
        {
            var checksum = ps.GetCheckSum();
            var db = new x360ceModelContainer();
            var s1 = db.Settings.FirstOrDefault(x => x.InstanceGuid == s.InstanceGuid && x.FileName == s.FileName && x.FileProductName == s.FileProductName);
            var n = DateTime.Now;
            if (s1 == null)
            {
                s1 = new Setting();
                s1.SettingId = Guid.NewGuid();
                s1.DateCreated = n;
                db.Settings.AddObject(s1);
            }
            s1.Comment = s.Comment;
            s1.DateUpdated = n;
            s1.DateSelected = n;
            s1.DeviceType = s.DeviceType;
            s1.FileName = s.FileName;
            s1.FileProductName = s.FileProductName;
            s1.InstanceGuid = s.InstanceGuid;
            s1.InstanceName = s.InstanceName;
            s1.ProductGuid = s.ProductGuid;
            s1.ProductName = s.ProductName;
            s1.IsEnabled = s.IsEnabled;
            s1.PadSettingChecksum = checksum;
            // Save Pad Settings.
            var p1 = db.PadSettings.FirstOrDefault(x => x.PadSettingChecksum == checksum);
            if (p1 == null)
            {
                p1 = new PadSetting();
                p1.PadSettingChecksum = checksum;
                db.PadSettings.AddObject(p1);
            }
            p1.AxisToDPadDeadZone = ps.AxisToDPadDeadZone;
            p1.AxisToDPadEnabled = ps.AxisToDPadEnabled;
            p1.AxisToDPadOffset = ps.AxisToDPadOffset;
            p1.ButtonA = ps.ButtonA;
            p1.ButtonB = ps.ButtonB;
            p1.ButtonBig = string.IsNullOrEmpty(ps.ButtonBig) ? "" : ps.ButtonBig;
            p1.ButtonGuide = string.IsNullOrEmpty(ps.ButtonGuide) ? "" : ps.ButtonGuide;
            p1.ButtonBack = ps.ButtonBack;
            p1.ButtonStart = ps.ButtonStart;
            p1.ButtonX = ps.ButtonX;
            p1.ButtonY = ps.ButtonY;
            p1.DPad = ps.DPad;
            p1.DPadDown = ps.DPadDown;
            p1.DPadLeft = ps.DPadLeft;
            p1.DPadRight = ps.DPadRight;
            p1.DPadUp = ps.DPadUp;
            p1.ForceEnable = ps.ForceEnable;
            p1.ForceOverall = ps.ForceOverall;
            p1.ForceSwapMotor = ps.ForceSwapMotor;
            p1.ForceType = ps.ForceType;
            p1.GamePadType = ps.GamePadType;
            p1.LeftMotorPeriod = ps.LeftMotorPeriod;
            p1.LeftMotorStrength = string.IsNullOrEmpty(ps.LeftMotorStrength) ? "100" : ps.LeftMotorStrength;
            p1.LeftShoulder = ps.LeftShoulder;
            p1.LeftThumbAntiDeadZoneX = ps.LeftThumbAntiDeadZoneX;
            p1.LeftThumbAntiDeadZoneY = ps.LeftThumbAntiDeadZoneY;
            p1.LeftThumbAxisX = ps.LeftThumbAxisX;
            p1.LeftThumbAxisY = ps.LeftThumbAxisY;
            p1.LeftThumbButton = ps.LeftThumbButton;
            p1.LeftThumbDeadZoneX = ps.LeftThumbDeadZoneX;
            p1.LeftThumbDeadZoneY = ps.LeftThumbDeadZoneY;
            p1.LeftThumbLinearX = string.IsNullOrEmpty(ps.LeftThumbLinearX) ? "" : ps.LeftThumbLinearX;
            p1.LeftThumbLinearY = string.IsNullOrEmpty(ps.LeftThumbLinearY) ? "" : ps.LeftThumbLinearY;
            p1.LeftThumbDown = ps.LeftThumbDown;
            p1.LeftThumbLeft = ps.LeftThumbLeft;
            p1.LeftThumbRight = ps.LeftThumbRight;
            p1.LeftThumbUp = ps.LeftThumbUp;
            p1.LeftTrigger = ps.LeftTrigger;
            p1.LeftTriggerDeadZone = ps.LeftTriggerDeadZone;
            p1.PassThrough = ps.PassThrough;
            p1.RightMotorPeriod = ps.RightMotorPeriod;
            p1.RightMotorStrength = string.IsNullOrEmpty(ps.RightMotorStrength) ? "100" : ps.RightMotorStrength;
            p1.RightShoulder = ps.RightShoulder;
            p1.RightThumbAntiDeadZoneX = ps.RightThumbAntiDeadZoneX;
            p1.RightThumbAntiDeadZoneY = ps.RightThumbAntiDeadZoneY;
            p1.RightThumbLinearX = string.IsNullOrEmpty(ps.RightThumbLinearX) ? "" : ps.RightThumbLinearX;
            p1.RightThumbLinearY = string.IsNullOrEmpty(ps.RightThumbLinearY) ? "" : ps.RightThumbLinearY;
            p1.RightThumbAxisX = ps.RightThumbAxisX;
            p1.RightThumbAxisY = ps.RightThumbAxisY;
            p1.RightThumbButton = ps.RightThumbButton;
            p1.RightThumbDeadZoneX = ps.RightThumbDeadZoneX;
            p1.RightThumbDeadZoneY = ps.RightThumbDeadZoneY;
            p1.RightThumbDown = ps.RightThumbDown;
            p1.RightThumbLeft = ps.RightThumbLeft;
            p1.RightThumbRight = ps.RightThumbRight;
            p1.RightThumbUp = ps.RightThumbUp;
            p1.RightTrigger = ps.RightTrigger;
            p1.RightTriggerDeadZone = ps.RightTriggerDeadZone;
            db.SaveChanges();
            db.Dispose();
            db = null;
            return "";
        }

        /// <summary>
        /// Search controller settings.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true, Description = "Search controller settings.")]
        public SearchResult SearchSettings(SearchParameter[] args)
        {
            var sr = new SearchResult();
            var db = new x360ceModelContainer();
            // Get all device instances of the user.
            var instances = args.Where(x => x.InstanceGuid != Guid.Empty).Select(x => x.InstanceGuid).Distinct().ToArray();
            if (instances.Length == 0)
            {
                sr.Settings = new Setting[0];
            }
            else
            {
                // Get all settings attached to user's device instances.
                sr.Settings = db.Settings.Where(x => instances.Contains(x.InstanceGuid))
                    .OrderBy(x => x.ProductName).ThenBy(x => x.FileName).ThenBy(x => x.FileProductName).ToArray();
            }
            // Get list of products (unique identifiers).
            var products = args.Where(x => x.ProductGuid != Guid.Empty).Select(x => x.ProductGuid).Distinct().ToArray();
            var files = args.Where(x => !string.IsNullOrEmpty(x.FileName) || !string.IsNullOrEmpty(x.FileProductName)).ToList();
            if (products.Length == 0)
            {
                sr.Summaries = new Summary[0];
            }
            else
            {
                files.Add(new SearchParameter() { FileName = "", FileProductName = "" });
                Expression body = null;
                var param = Expression.Parameter(typeof(Summary), "x");
                var pgParam = Expression.PropertyOrField(param, "ProductGuid");
                var fnParam = Expression.PropertyOrField(param, "FileName");
                var fpParam = Expression.PropertyOrField(param, "FileProductName");
                for (int i = 0; i < products.Length; i++)
                {
                    var productGuid = products[i];
                    for (int f = 0; f < files.Count; f++)
                    {
                        var fileName = files[f].FileName;
                        var fileProductName = files[f].FileProductName;
                        var exp1 = Expression.AndAlso(
                                Expression.Equal(pgParam, Expression.Constant(productGuid)),
                                Expression.Equal(fnParam, Expression.Constant(fileName))
                           );
                        exp1 = Expression.AndAlso(exp1, Expression.Equal(fpParam, Expression.Constant(fileProductName)));
                        body = body == null ? exp1 : Expression.OrElse(body, exp1).Reduce();
                    }
                }
                var lambda = Expression.Lambda<Func<Summary, bool>>(body, param);
                // Select only TOP 10 configurations per per controller and file.
                var summaries = db.Summaries.Where(lambda).ToArray();
                var topSummaries = new List<Summary>();
                var productGuids = db.Summaries.Where(lambda).Select(x => x.ProductGuid).Distinct();
                foreach (var pg in productGuids)
                {
                    var controllerSummaries = summaries.Where(x => x.ProductGuid == pg);
                    var fileNames = controllerSummaries.Select(x => x.FileName).Distinct();
                    foreach (var fileName in fileNames)
                    {
                        // Top 10 configurations per file
                        topSummaries.AddRange(controllerSummaries.Where(x => x.FileName == fileName).OrderByDescending(x => x.Users).Take(10));
                    }
                }
                sr.Summaries = topSummaries.OrderBy(x => x.ProductName).ThenBy(x => x.FileName).ThenBy(x => x.FileProductName).ThenBy(x => x.Users).ToArray();
            }
            db.Dispose();
            db = null;
            return sr;
        }

        [WebMethod(EnableSession = true, Description = "Delete controller settings.")]
        public string DeleteSetting(Setting s)
        {
            var db = new x360ceModelContainer();
            var setting = db.Settings.FirstOrDefault(x => x.InstanceGuid == s.InstanceGuid && x.FileName == s.FileName && x.FileProductName == s.FileProductName);
            if (setting == null) return "Setting not found";
            db.Settings.DeleteObject(setting);
            db.SaveChanges();
            db.Dispose();
            db = null;
            return "";
        }

        /// <summary>
        /// Load controller settings.
        /// </summary>
        /// <param name="checksum">List of unique identifiers of PAD setting</param>
        /// <returns>List of PAD settings.</returns>
        [WebMethod(EnableSession = true, Description = "Load controller settings.")]
        public SearchResult LoadSetting(Guid[] checksum)
        {
            var sr = new SearchResult();
            var db = new x360ceModelContainer();
            sr.PadSettings = db.PadSettings.Where(x => checksum.Contains(x.PadSettingChecksum)).ToArray();
            db.Dispose();
            db = null;
            return sr;
        }

        [WebMethod(EnableSession = true, Description = "Get vendors of controllers.")]
        public List<Vendor> GetVendors()
        {
            var db = new x360ceModelContainer();
            var q = from row in db.Vendors
                    select new Vendor
                    {
                        VendorId = row.VendorId,
                        VendorName = row.VendorName,
                        ShortName = row.ShortName,
                        WebSite = row.WebSite
                    };
            var vendors = q.ToList();
            db.Dispose();
            db = null;
            return vendors;
        }

        [WebMethod(EnableSession = true, Description = "Get default list of games.")]
        public SettingsData GetSettingsData()
        {
            var data = new SettingsData();
            var db = new x360ceModelContainer();
            data.Programs = db.Programs.Where(x => x.IsEnabled && x.InstanceCount > 1).ToList();
            db.Dispose();
            db = null;
            return data;
        }

        [WebMethod(EnableSession = true, Description = "Get list of games.")]
        public List<Program> GetProgramsDefault()
        {
            return GetPrograms(EnabledState.Enabled, 2);
        }

        List<Program> GetOverridePrograms()
        {
            List<Program> programs = new List<Program>();
            var key = "OverridePrograms";
            var settings = System.Web.Configuration.WebConfigurationManager.AppSettings;
            if (settings.AllKeys.Contains(key))
            {
                var path = settings[key];
                var fileName = Server.MapPath(path);
                if (System.IO.File.Exists(fileName))
                {
                    var xml = System.IO.File.ReadAllText(fileName);
                    programs = Serializer.DeserializeFromXmlString<List<Program>>(xml, System.Text.Encoding.UTF8);
                }
            }
            return programs;
        }



        [WebMethod(EnableSession = true, Description = "Get list of games.")]
        public List<Program> GetPrograms(EnabledState isEnabled, int minInstanceCount)
        {
            var programs = GetOverridePrograms();
            if (programs == null)
            {
                var db = new x360ceModelContainer();
                IQueryable<Program> list = db.Programs;
                if (isEnabled == EnabledState.Enabled) list = list.Where(x => x.IsEnabled);
                else if (isEnabled == EnabledState.Disabled) list = list.Where(x => !x.IsEnabled);
                if (minInstanceCount > 0) list = list.Where(x => x.InstanceCount == minInstanceCount);
                programs = list.ToList();
                db.Dispose();
                db = null;
            }
            return programs;
        }

        [WebMethod(EnableSession = true, Description = "Get most popular presets.")]
        public SearchResult GetPresets()
        {
            var sr = new SearchResult();
            var db = new x360ceModelContainer();
            IQueryable<Program> list = db.Programs;
            // Not used.          
            sr.Settings = new Setting[0];
            // Contains TOP 20 most popular DirectInput devices.
            var query = db.Products.OrderByDescending(x => x.InstanceCount).Take(20);
            var products = query.ToArray();
            var productGuids = products.Select(x => x.ProductGuid).ToArray();
            // Select TOP products
            var query2 =
                // Select most popular devices.
                from row in query
                // Join all sumaries for these devices.
                join sum in db.Summaries on row.ProductGuid equals sum.ProductGuid
                // Group in order to identify most popular PAD setting for the device.
                group sum by new { sum.ProductGuid, sum.PadSettingChecksum } into g
                select g.OrderByDescending(x => x.Users).First();

            var padSettingGuids = query2.ToList();
            // Fill summaries.
            sr.Summaries = padSettingGuids.Select(x => new Summary()
            {
                ProductGuid = x.ProductGuid,
                ProductName = x.ProductName,
                PadSettingChecksum = x.PadSettingChecksum,
            }).ToArray();
            var settingChecksums = padSettingGuids.Select(x => x.PadSettingChecksum).ToArray();
            //// Join all pad setings related to summaries.
            //join pad in db.PadSettings on sum.PadSettingChecksum equals pad.PadSettingChecksum
            //select new
            //{
            //    Summary = sum,
            //    PadSetting = pad,
            //};
            // Contains most popular PAD Setting for device.
            sr.PadSettings = new PadSetting[0];
            // Code here.
            db.Dispose();
            db = null;
            return sr;
        }

        [WebMethod(EnableSession = true, Description = "Search games.")]
        public Program GetProgram(string fileName, string fileProductName)
        {
            var db = new x360ceModelContainer();
            var o = db.Programs.FirstOrDefault(x => x.FileName == fileName && x.FileProductName == fileProductName);
            if (o != null) return o;
            o = db.Programs.FirstOrDefault(x => x.FileName == fileName);
            db.Dispose();
            db = null;
            return o;
        }

        [WebMethod(EnableSession = true, Description = "Save program settings.")]
        public string SetProgram(Program p)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var db = new x360ceModelContainer();
                var o = db.Programs.FirstOrDefault(x => x.FileName == p.FileName && x.FileProductName == p.FileProductName);
                if (o == null)
                {
                    o = new Program();
                    o.ProgramId = Guid.NewGuid();
                    o.DateCreated = DateTime.Now;
                    o.FileName = p.FileName;
                    o.FileProductName = p.FileProductName;
                    db.Programs.AddObject(o);
                }
                else
                {
                    o.DateUpdated = DateTime.Now;
                }
                o.HookMask = p.HookMask;
                o.InstanceCount = p.InstanceCount;
                o.IsEnabled = p.IsEnabled;
                o.XInputMask = p.XInputMask;
                db.SaveChanges();
                db.Dispose();
                db = null;
                return "";
            }
            else
            {
                return "User was not authenticated.";
            }
        }

        [WebMethod(EnableSession = true, Description = "Sign out.")]
        public KeyValueList SignOut()
        {
            FormsAuthentication.SignOut();
            var results = new KeyValueList();
            results.Add("Status", true);
            results.Add("Message", "Good bye!");
            return results;
        }

        [WebMethod(EnableSession = true, Description = "Sign in.")]
        public KeyValueList SignIn(string username, string password)
        {
            string errorMessage = string.Empty;
            if (password.Length == 0) errorMessage = "Please enter password";
            if (username.Length == 0) errorMessage = "Please enter user name";
            if (errorMessage.Length == 0)
            {
                // Here must be validation with password. You can add third party validation here;
                bool success = Membership.ValidateUser(username, password);
                if (!success) errorMessage = "Validation failed. User name '" + username + "' was not found.";
            }
            var results = new KeyValueList();
            if (errorMessage.Length > 0)
            {
                results.Add("Status", false);
                results.Add("Message", errorMessage);
            }
            else
            {
                FormsAuthentication.Initialize();
                var user = Membership.GetUser(username, true);
                if (user == null)
                {
                    results.Add("Status", false);
                    results.Add("Message", "'" + username + "' was not found.");
                }
                else
                {
                    var roles = Roles.GetRolesForUser(username);
                    string rolesString = string.Empty;
                    for (int i = 0; i < roles.Length; i++)
                    {
                        if (i > 0) rolesString += ",";
                        rolesString += roles[i];
                    }
                    var loginRememberMinutes = 30;
                    var ticket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddMinutes(loginRememberMinutes), true, rolesString, FormsAuthentication.FormsCookiePath);
                    // Encrypt the cookie using the machine key for secure transport.
                    var hash = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash); // Hashed ticket
                    // Set the cookie's expiration time to the tickets expiration time
                    if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    // Create Identity.
                    var identity = new System.Security.Principal.GenericIdentity(user.UserName);
                    // Create Principal.
                    var principal = new RolePrincipal(identity);
                    System.Threading.Thread.CurrentPrincipal = principal;
                    // Create User.
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(identity, roles);
                    results.Add("Status", true);
                    results.Add("Message", "Welcome!");
                }
            }
            return results;
        }

    }

}
