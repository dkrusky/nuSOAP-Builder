Public Class frmConfig

    Private Sub frmConfig_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SettingsSave()
        Me.Dispose()
    End Sub
    Private Sub frmConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SettingsLoad()
    End Sub

    Private Sub SettingsSave()
        My.Settings.DEBUG = ToggleSwitch1.IsOn
        My.Settings.PUSH_GCM_SANDBOX = ToggleSwitch2.IsOn
        My.Settings.PUSH_APNS_SANDBOX = ToggleSwitch3.IsOn
        My.Settings.PUSH_GCM_KEY_LIVE = TextEdit1.Text
        My.Settings.PUSH_GCM_SOUND_LIVE = TextEdit2.Text
        My.Settings.PUSH_GCM_KEY = TextEdit3.Text
        My.Settings.PUSH_GCM_SOUND = TextEdit4.Text
        My.Settings.PUSH_APNS_CERTIFICATE_LIVE = TextEdit7.Text
        My.Settings.PUSH_APNS_CERTIFICATE_PASSPHRASE_LIVE = TextEdit8.Text
        My.Settings.PUSH_APNS_SOUND_LIVE = TextEdit5.Text
        My.Settings.PUSH_APNS_CERTIFICATE = TextEdit6.Text
        My.Settings.PUSH_APNS_CERTIFICATE_PASSPHRASE = TextEdit9.Text
        My.Settings.PUSH_APNS_SOUND = TextEdit10.Text
        My.Settings.PUSH_UA_APP_KEY = TextEdit12.Text
        My.Settings.PUSH_UA_APP_SECRET = TextEdit13.Text
        My.Settings.PUSH_UA_SOUND = TextEdit11.Text
        My.Settings.DB_HOST = txtDB_HOST.Text
        My.Settings.DB_USER = txtDB_USER.Text
        My.Settings.DB_PASS = txtDB_PASS.Text
        My.Settings.DB_NAME = txtDB_DATA.Text
        My.Settings.DB_PREFIX = txtDB_PREFIX.Text
        My.Settings.Save()
    End Sub

    Private Sub SettingsLoad()
        ToggleSwitch1.IsOn = My.Settings.DEBUG
        ToggleSwitch2.IsOn = My.Settings.PUSH_GCM_SANDBOX
        ToggleSwitch3.IsOn = My.Settings.PUSH_APNS_SANDBOX
        TextEdit1.Text = My.Settings.PUSH_GCM_KEY_LIVE
        TextEdit2.Text = My.Settings.PUSH_GCM_SOUND_LIVE
        TextEdit3.Text = My.Settings.PUSH_GCM_KEY
        TextEdit4.Text = My.Settings.PUSH_GCM_SOUND
        TextEdit7.Text = My.Settings.PUSH_APNS_CERTIFICATE_LIVE
        TextEdit8.Text = My.Settings.PUSH_APNS_CERTIFICATE_PASSPHRASE_LIVE
        TextEdit5.Text = My.Settings.PUSH_APNS_SOUND_LIVE
        TextEdit6.Text = My.Settings.PUSH_APNS_CERTIFICATE
        TextEdit9.Text = My.Settings.PUSH_APNS_CERTIFICATE_PASSPHRASE
        TextEdit10.Text = My.Settings.PUSH_APNS_SOUND
        TextEdit12.Text = My.Settings.PUSH_UA_APP_KEY
        TextEdit13.Text = My.Settings.PUSH_UA_APP_SECRET
        TextEdit11.Text = My.Settings.PUSH_UA_SOUND
        txtDB_HOST.Text = My.Settings.DB_HOST
        txtDB_USER.Text = My.Settings.DB_USER
        txtDB_PASS.Text = My.Settings.DB_PASS
        txtDB_DATA.Text = My.Settings.DB_NAME
        txtDB_PREFIX.Text = My.Settings.DB_PREFIX
    End Sub
End Class