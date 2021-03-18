export default {
    UserPhotoHash:
        process.env.NODE_ENV === "production"
            ? document.location.origin + "/StaticFiles/Employees/Thumbnails/"
            : `${process.env.serverUrl}/StaticFiles/Employees/Thumbnails/`,
    OidcConfiguration: `/_configuration/${process.env.oidcClientId}`,
    account: `/Identity/Account/Manage`
};
