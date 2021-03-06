﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebApiStudent_Net_Core2.Models;

namespace WebApiStudent_Net_Core2.ConstDeclarations
{
    public enum WhichCharacterScaleENUM
    {
        Character_7_ENUM = 1,
        Character_13_ENUM = 2
    }

    public class Const
    {
        public static int DataBaseZeroValue = 0;

        public static readonly DataBaseOperationInfo[] DataBaseOperationInfoArray =
        {
            new DataBaseOperationInfo(ThisDataBaseOperation: DataBaseOperation.SaveData_Enum, ThisDataBaseOperationString: "Gemme Data"),
            new DataBaseOperationInfo(ThisDataBaseOperation: DataBaseOperation.DeleteData_Enum, ThisDataBaseOperationString: "Slette Data"),
            new DataBaseOperationInfo(ThisDataBaseOperation: DataBaseOperation.UpdateData_Enum, ThisDataBaseOperationString: "Opdatere Data"),
            new DataBaseOperationInfo(ThisDataBaseOperation: DataBaseOperation.ReadData_Enum, ThisDataBaseOperationString: "Læse Data"),
        };
        public static string FindDataBaseOperationString(DataBaseOperation CurrentDataBaseOperation)
        {
            int ReturnStringCounter = 0;

            do
            {
                if (DataBaseOperationInfoArray[ReturnStringCounter].ThisDataBaseOperation == CurrentDataBaseOperation)
                {
                    return (DataBaseOperationInfoArray[ReturnStringCounter].ThisDataBaseOperationString);
                }
                else
                {
                    ReturnStringCounter++;
                }
            } while (ReturnStringCounter < DataBaseOperationInfoArray.Length);

            return ("Ingen string fundet der hører til søgt nummer !!!");
        }

        public static readonly TableOperationInfo[] TableOperationInfoArray =
        {
            new TableOperationInfo(ThisModelDatabaseNumber: ModelDatabaseNumber.Absence_Enum, ThisModelDatabaseNumberString: "Absence Tabel"),
            new TableOperationInfo(ThisModelDatabaseNumber: ModelDatabaseNumber.Character7Scale_Enum, ThisModelDatabaseNumberString: "Character7Scale Tabel"),
            new TableOperationInfo(ThisModelDatabaseNumber: ModelDatabaseNumber.Character13Scale_Enum, ThisModelDatabaseNumberString: "Character13Scale Tabel"),
            new TableOperationInfo(ThisModelDatabaseNumber: ModelDatabaseNumber.ContactForm_Enum, ThisModelDatabaseNumberString: "Contactform Tabel"),
            new TableOperationInfo(ThisModelDatabaseNumber: ModelDatabaseNumber.Course_Enum, ThisModelDatabaseNumberString: "Course Tabel"),
            new TableOperationInfo(ThisModelDatabaseNumber: ModelDatabaseNumber.EducationLine_Enum, ThisModelDatabaseNumberString: "EducationLine Tabel"),
            new TableOperationInfo(ThisModelDatabaseNumber: ModelDatabaseNumber.Education_Enum, ThisModelDatabaseNumberString: "Education Tabel"),
            new TableOperationInfo(ThisModelDatabaseNumber: ModelDatabaseNumber.UserFile_Enum, ThisModelDatabaseNumberString: "UserFile Tabel"),
            new TableOperationInfo(ThisModelDatabaseNumber: ModelDatabaseNumber.UserInfo_Enum, ThisModelDatabaseNumberString: "UserInfo Tabel"),
            new TableOperationInfo(ThisModelDatabaseNumber: ModelDatabaseNumber.User_Education_Character_Course_Collection_Enum, ThisModelDatabaseNumberString: "User_Education_Character_Course_Collection Tabel"),
            new TableOperationInfo(ThisModelDatabaseNumber: ModelDatabaseNumber.User_Eductaion_Time_Collection_Enum, ThisModelDatabaseNumberString: "User_Eductaion_Time_Collection Tabel")
        };

        public static string FindTableOperationString(ModelDatabaseNumber CurrentModelDatabaseNumber)
        {
            int ReturnStringCounter = 0;

            do
            {
                if (TableOperationInfoArray[ReturnStringCounter].ThisModelDatabaseNumber == CurrentModelDatabaseNumber)
                {
                    return (TableOperationInfoArray[ReturnStringCounter].ThisModelDatabaseNumberString);
                }
                else
                {
                    ReturnStringCounter++;
                }
            } while (ReturnStringCounter < TableOperationInfoArray.Length);

            return ("Ingen string fundet der hører til søgt nummer !!!");
        }

        public static readonly string PasswordHash = "P@@Sw0rd";
        public static readonly string SaltKey = "S@LT&KEY";
        public static readonly string VIKey = "@1B2c3D4e5F6g7H8";
        private static readonly string NoReturnStringFound = "Ingen string fundet der hører til søgt nummer !!!";

        public const int WrongModelState = -18;
        public const int UserAlreadySignedUpForEducation = -17;
        public const int WrongjSonObjectParameters = -16;
        public const int SpecifiedContentStillInUseInTablesBelow = -15;
        public const int WrongCharacterScaleProvided = -14;
        public const int WrongCharacterProvided = -13;
        public const int NoCharacterProvidedButCharacterScaleProvided = -12;
        public const int CharacterProvidedButNoCharacterScaleProvided = -11;
        public const int InformationNotProvided = -10;
        public const int ObjectNotSavedByCurrentUserOriginally = -9;
        public const int UserNameAlreadyPresent = -8;
        public const int FeatureNotImplemented = -7;
        public const int ObjectNotFound = -6;
        public const int ObjectAlreadyPresent = -5;
        public const int SaveOperationFailed = -4;
        public const int UpdateOperationFailed = -3;
        public const int DeleteOperationFailed = -2;
        public const int UserNotFound = -1;
        public const int OperationOkHigherValueThanHere = 0;
        public const int UpdateOperationOk = 1;
        public const int SaveOperationOk = 2;
        public const int DeleteOperationOk = 3;

        public static readonly ReturnCodesAndStrings[] ReturnCodesAndReturnStringsArray =
        {
            new ReturnCodesAndStrings(ReturnCode : WrongModelState, ReturnString : "Wrong Model State"),
            new ReturnCodesAndStrings(ReturnCode : UserAlreadySignedUpForEducation, ReturnString : "Studerende er allerede tilmeldt dette Uddannelsesforløb på dette tidspunkt"),
            new ReturnCodesAndStrings(ReturnCode : WrongjSonObjectParameters, ReturnString : "Én eller flere af de forventede parametre i det give jSon objekt mangler !!!"),
            new ReturnCodesAndStrings(ReturnCode : SpecifiedContentStillInUseInTablesBelow, ReturnString : "ID i denne tabel der ønsket slettet er stadigvæk i brug i underliggende tabeller. Slet i disse tabeller først !!!"),
            new ReturnCodesAndStrings(ReturnCode : WrongCharacterScaleProvided, ReturnString : "Forkert ID for karakterskale angivet"),
            new ReturnCodesAndStrings(ReturnCode : WrongCharacterProvided, ReturnString : "Forkert karakterværdi i forhold til valgt karakterskala angivet"),
            new ReturnCodesAndStrings(ReturnCode : NoCharacterProvidedButCharacterScaleProvided, ReturnString : "Ingen karakterværdi angivet selvom karakterskala er angivet"),
            new ReturnCodesAndStrings(ReturnCode : CharacterProvidedButNoCharacterScaleProvided, ReturnString : "Ingen karakterskala angivet selvom karakterværdi er angivet"),
            new ReturnCodesAndStrings(ReturnCode : InformationNotProvided, ReturnString : "Information er ikke gemt"),
            new ReturnCodesAndStrings(ReturnCode : ObjectNotSavedByCurrentUserOriginally, ReturnString : "Objekt er ikke gemt af nuværende bruger oprindeligt !!!"),
            new ReturnCodesAndStrings(ReturnCode : UserNameAlreadyPresent, ReturnString : "Brugernavn eksisterer allerede !!!"),
            new ReturnCodesAndStrings(ReturnCode : FeatureNotImplemented, ReturnString : "Feature er ikke implementeret/er ikke enabled !!!"),
            new ReturnCodesAndStrings(ReturnCode : ObjectNotFound, ReturnString : "objekt er ikke fundet !!!"),
            new ReturnCodesAndStrings(ReturnCode : ObjectAlreadyPresent, ReturnString : "objekt er allerede tilgængelig !!!"),
            new ReturnCodesAndStrings(ReturnCode : SaveOperationFailed, ReturnString : "Fejl under lagring af objekt !!!"),
            new ReturnCodesAndStrings(ReturnCode : UpdateOperationFailed, ReturnString : "Fejl under opdatering af objekt !!!"),
            new ReturnCodesAndStrings(ReturnCode : DeleteOperationFailed, ReturnString : "Fejl under sletning af objekt !!!"),
            new ReturnCodesAndStrings(ReturnCode : UserNotFound, ReturnString : "Bruger ikke fundet !!!"),
            new ReturnCodesAndStrings(ReturnCode : OperationOkHigherValueThanHere, ReturnString : "Returværdier større end denne værdi er ok returværdier"),
            new ReturnCodesAndStrings(ReturnCode : UpdateOperationOk, ReturnString : "Objekt er opdateret korrekt"),
            new ReturnCodesAndStrings(ReturnCode : SaveOperationOk, ReturnString : "Objekt er gemt korrekt"),
            new ReturnCodesAndStrings(ReturnCode : DeleteOperationOk, ReturnString : "Objekt er slettet korrekt")
        };

        public static string FindReturnString(int ReturnCode)
        {
            int ReturnStringCounter = 0;

            do
            {
                if (ReturnCodesAndReturnStringsArray[ReturnStringCounter].ReturnCode == ReturnCode)
                {
                    return (ReturnCodesAndReturnStringsArray[ReturnStringCounter].ReturnString);
                }
                else
                {
                    ReturnStringCounter++;
                }
            } while (ReturnStringCounter < ReturnCodesAndReturnStringsArray.Length);

            return (NoReturnStringFound);
        }

        public static string GenerateReturnNumberString(int ReturnCode)
        {
            string ReturnString = FindReturnString(ReturnCode);

            if (NoReturnStringFound == ReturnString)
            {
                return (ReturnString);
            }
            else
            {
                return (ReturnCode + " " + ReturnString);
            }
        }
    }

}