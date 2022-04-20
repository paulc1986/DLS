using DLS.Utils;
using Rage;

namespace DLS
{
    public class ActiveVehicle
    {
        public ActiveVehicle(Vehicle vehicle, bool playerVehicle = false, LightStage lightStage = LightStage.Off, SirenStage sirenStage = SirenStage.Off)
        {
            Vehicle = vehicle;
            LightStage = lightStage;
            SirenStage = sirenStage;
            CurrentHash = 0;
            TAStage = TAStage.Off;
            TempUsed = false;
            TempLightStage = LightStage.Off;
            TempWailLightStage = LightStage.Off;
            AuxOn = false;
            AuxID = 999;
            HornID = 999;
            SoundId = 999;
            PlayerVehicle = false;
            SBOn = false;
            IntLightOn = false;
            IndStatus = IndStatus.Off;
            TAType = "off";
            TAgroup = null;
            TApatternCurrentIndex = 999;
            PlayerVehicle = playerVehicle;
            DefaultEL = vehicle.EmergencyLighting;
            IsSirenSilent = vehicle.IsSirenSilent;
            //add by paulchopping1986
            Sign = 8; //ExtraNumber
            Takedown = 9;//ExtraNumber
            RightAlly = 11;//ExtraNumber
            LeftAlly = 10;//ExtraNumber
            RearLight = 12;//ExtraNumber
            //end add by paulchopping1986

            IsScanOn = false;
            if (vehicle && vehicle.GetDLS() != null)
            {
                bool temp = vehicle.IsSirenOn;
                vehicle.IsSirenOn = false;
                InitialLengths = new float[20];
                GameFiber.Yield();
                for (int i = 0; i < InitialLengths.Length; i++)
                {
                    string bone = "siren" + (i + 1);
                    if (vehicle.HasBone(bone))
                    {
                        InitialLengths[i] = vehicle.GetBoneOrientation(bone).LengthSquared();
                    }
                    else
                    {
                        InitialLengths[i] = 1f;
                    }
                }
                vehicle.IsSirenOn = temp;
                DLSModel vehDLS;
                if (vehicle)
                    vehDLS = vehicle.GetDLS();
                else
                    vehDLS = null;
                TAType = vehDLS.TrafficAdvisory.Type;
                if (TAType != "off")
                {
                    TAgroup = Entrypoint.tagroups[vehDLS.TrafficAdvisory.TAgroup];
                    TApatternCurrentIndex = Entrypoint.tagroups[vehDLS.TrafficAdvisory.TAgroup].GetIndexFromTAPatternName(vehDLS.TrafficAdvisory.DefaultTApattern);
                }
                vehicle.EmergencyLightingOverride = Vehicles.GetEL(vehicle, this);
            }
        }
        public Vehicle Vehicle { get; set; }
        public LightStage LightStage { get; set; }
        public LightStage TempLightStage { get; set; }
        public bool TempUsed { get; set; } = true;
        public bool Wailing { get; set; }
        public string TAType { get; set; }
        public LightStage TempWailLightStage { get; set; }
        public SirenStage SirenStage { get; set; }
        public TAStage TAStage { get; set; }
<<<<<<< Updated upstream
=======
        
        public bool blktOn { get; set; }
        //add by paulchopping1986
        public int Sign { get; set; }
        public int Takedown { get; set; }
        public int RightAlly { get; set; }
        public int LeftAlly { get; set; }
        public int RearLight { get; set; }

        //end add by paulchopping1986
>>>>>>> Stashed changes
        public bool SBOn { get; set; }
        public bool AuxOn { get; set; }
        public bool HornOn { get; set; }
        public bool PlayerVehicle { get; set; }
        public bool IntLightOn { get; set; }
        public int AuxID { get; set; }
        public int HornID { get; set; }
        public int SoundId { get; set; }
        public IndStatus IndStatus { get; set; }
        public TAgroup TAgroup { get; set; }
        public int TApatternCurrentIndex { get; set; }
        public uint CurrentHash { get; set; }
        public float[] InitialLengths { get; set; }
        public EmergencyLighting DefaultEL { get; set; }
        public bool IsSirenSilent { get; set; }
        public bool IsScanOn { get; set; }
<<<<<<< Updated upstream
=======

        public int? AirManuState { get; set; } = null;
        public int? AirManuID { get; set; } = null;
        public bool IsUsingManual { get; set; } = false;
>>>>>>> Stashed changes
    }

    public enum LightStage
    {
        Off,
        One,
        Two,
        Three,
        CustomOne,
        CustomTwo,
        Empty
    }

    public enum SirenStage
    {
        Off,
        One,
        Two,
        Warning,
        Warning2,
        Horn
    }

    public enum TAStage
    {
        Off,
        Left,
        Diverge,
        Right,
        Warn
    }

    public enum IndStatus
    {
        Left,
        Right,
        Both,
        Off
    }

    public enum SirenStatus
    {
        On,
        Off,
        None
    }
}
