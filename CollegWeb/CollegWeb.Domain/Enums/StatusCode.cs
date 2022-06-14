namespace CollegWeb.Domain.Enums
{
    public enum StatusCode
    {
        UserNotFound = 8,
        LessonNotFound = 9,
        GroupNotFound = 10,

        UserNotCreated = 11,
        LessonNotCreated = 12,
        GroupNotCreated = 13,

        UserNotUpdated = 14,
        LessonNotUpdated = 15,
        GroupNotUpdated = 16,

        UserNotDeleted = 17,
        LessonNotDeleted = 18,
        GroupNotDeleted = 19,

        ModelIsNullOrEmpty = 20,

        TryCatchError = 21,

        OK = 200,
        InternalServerError = 500
    }
}
