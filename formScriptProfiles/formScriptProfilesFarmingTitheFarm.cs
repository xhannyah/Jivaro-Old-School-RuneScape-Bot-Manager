﻿using Jivaro_Old_School_RuneScape_Bot_Manager.methodClasses;
using System.ComponentModel;
using System.Reflection;


namespace Jivaro_Old_School_RuneScape_Bot_Manager.formScriptProfiles
{
    public partial class formScriptProfilesFarmingTitheFarm : Form
    {

        // Initialize Instances
        public formMainForm MainForm;

        public formScriptProfilesFarmingTitheFarm(formMainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }

        // Initialize Variables
        string boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:false</Replace>";
        string boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:false</Replace>";
        string boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:false</Replace>";
        string boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:false</Replace>";
        string boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:false</Replace>";
        string boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:false</Replace>";
        string filepathProfileFarmingTitheFarm = Path.Combine(@"C:\\Users\\" + Environment.UserName.ToString() + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxFarming-TitheFarm.txt");


        // Form load
        public void formScriptProfiles_FarmingTitheFarm_Load(object sender, EventArgs e)
        {

        }

        // Cancel Non Numbers & Set Limit To 99 From Textbox
        public void GlobalMethod_CancelNonNumbers_SetLimitTo99_KeyPress(object sender, KeyPressEventArgs e)
        {
            invokeMethodsPassiveGlobal.GlobalMethod_CancelNonNumbers_SetLimitTo99_KeyPress(sender, e);
        }

        // Require Input On Textbox
        public void GlobalMethod_RequireInput_Validating(object sender, CancelEventArgs e)
        {
            invokeMethodsPassiveGlobal.GlobalMethod_RequireInput_Validating(sender, e);
        }

        // Btn Click - Save Profile
        public void btnScriptProfiles_FarmingTitheFarm_SaveButton_Click(object sender, EventArgs e)
        {
            // Set Checkbox Variables
            var checkBoxMappings = new Dictionary<string, CheckBox>
            {
                {"boolEnableAntipattern", checkBoxScriptProfiles_FarmingTitheFarm_Antipattern},
                {"boolEnableDeathHandler", checkBoxScriptProfiles_FarmingTitheFarm_DeathHandler},
                {"boolEnableHopWorlds", checkBoxScriptProfiles_FarmingTitheFarm_WorldHopping},
                {"boolEnableRenewBond", checkBoxScriptProfiles_FarmingTitheFarm_RenewBond},
                {"boolEnableRestocking", checkBoxScriptProfiles_FarmingTitheFarm_Restocking},
                {"boolEnableSellLoot", checkBoxScriptProfiles_FarmingTitheFarm_SellLoot},
            };

            foreach (var checkboxPair in checkBoxMappings)
            {
                if (checkboxPair.Value.Checked)
                {
                    var variableName = checkboxPair.Key;
                    var variableValue = $"<Find>{variableName}:false</Find><Replace>{variableName}:true</Replace>";

                    // Using reflection to dynamically set field values
                    this.GetType().GetField(variableName, BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(this, variableValue);
                }
            }

            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileFarmingTitheFarm))
            {
                writer.WriteLine("General Settings");
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine("\nTithe Farm Settings");
                writer.WriteLine("<Find>23232323</Find><Replace>" + textBoxScriptProfiles_FarmingTitheFarm_StopLevel.Text + "</Replace>");
            }

            MessageBox.Show("Profile successfully created.");

        }
    }
}
