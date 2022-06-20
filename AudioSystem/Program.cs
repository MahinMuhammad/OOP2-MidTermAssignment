using System;

namespace AudioSystem
{
    interface RadioPlayerInterface
    {
        void Switch(bool on); 
        void retune(double frequency);
        void setVolume(int loudness);
        void changeChannel();
    }
    interface MusicPlayerInterface
    {
        void Switch(bool on);
        void play(bool on);
        void setVolume(int loudness);
        void playNext();
        void playPrevious();
    }
    class RadioPlayer : RadioPlayerInterface
    {
        private const String appName = "IRadio";
        private double frequency = 88.0; // default frequency;
        private int loudness = 100;
        private bool on = false;

        public void Switch(bool on)
        {
            this.on = on;
            if(on == true)
            {
                Console.WriteLine("\nRadio on...\n");
                showScreen();
            }
            else
            {
                Console.WriteLine("\nRadio off...\n");
            }
        }
        public void retune(double frequency)
        {
            if(on==true)
            {
                if (frequency > 0)
                {
                    this.frequency = frequency;
                    Console.WriteLine("\nFrequency changed...\n");
                    showScreen();
                }
                else
                {
                    Console.WriteLine("\nWrong frequency...\n");
                }
            }
            else
            {
                Console.WriteLine("\nSwitch on first...\n");
            }
        }
        public void setVolume(int loudness)
        {
            if(on==true)
            {
                if (loudness >= 0 && loudness<=100)
                {
                    this.loudness = loudness;
                    Console.WriteLine("\nLoudness changed...\n");
                    showScreen();
                }
                else
                {
                    Console.WriteLine("\nWrong loudness...\n");
                }
            }
            else
            {
                Console.WriteLine("\nSwitch on first!\n");
            }
        }
        public void changeChannel()
        {
            if(on==true)
            {
                Console.WriteLine("\nChannel changed...\n");
                frequency = frequency + 10;
                showScreen();
            }
            else
            {
                Console.WriteLine("\nSwitch on first!\n");
            }
        }
        public String getAppName()
        {
            return appName;
        }
        public void showScreen()
        {
            Console.WriteLine("*****" + appName + "*****");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Playing Frequency: " + frequency);
            Console.WriteLine("Volume: " + loudness);
        }
    }
    class MusicPlayer : MusicPlayerInterface
    {
        private const String appName = "IMusic";
        private bool playerOn = false;
        private bool musicOn = false;
        private int loudness = 100;
        private MusicFile mf;
        private IPod ipd;
        private int trackNumber = 0;

        public void Switch(bool on)
        {
            playerOn = on;
            if (playerOn == true)
            {
                Console.WriteLine("\nMusic Player on...\n");
                showScreen();
            }
            else
            {
                Console.WriteLine("\nMusic Player off...\n");
            }
        }
        public void play(bool on)
        {
            
            if(playerOn==true)
            {
                musicOn = on;
                if(musicOn==true)
                {
                    mf = ipd.loadTrack(trackNumber);
                    Console.WriteLine("\nPlaying...\n");
                    showScreen();
                }
                else
                {
                    Console.WriteLine("\nMusic Stopped...\n");
                }
            }
            else
            {
                Console.WriteLine("\nSwitch on the Player first!\n");
            }
        }
        public void setVolume(int loudness)
        {
            if(playerOn==true)
            {
                if (loudness >= 0 && loudness <= 100)
                {
                    this.loudness = loudness;
                    Console.WriteLine("\nLoudness changed...\n");
                    showScreen();
                }
                else
                {
                    Console.WriteLine("\nWrong loudness...\n");
                }
            }
            else
            {
                Console.WriteLine("\nSwitch on the Player first!\n");
            }
        }
        public void playNext()
        {
            if (playerOn == true)
            {
                if (ipd != null)
                {
                    if(trackNumber<500)
                    {
                        trackNumber++;
                        if (ipd.loadTrack(trackNumber) != null)
                        {
                            mf = ipd.loadTrack(trackNumber);
                            showScreen();
                        }
                        else
                        {
                            trackNumber--;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nGrant access to device storage!\n");
                }
            }
            else
            {
                Console.WriteLine("\nSwitch on the Player first!\n");
            }
        }
        public void playPrevious()
        {
            if (playerOn == true)
            {
                if (ipd != null)
                {
                    if(trackNumber>0)
                    {
                        trackNumber--;
                        mf = ipd.loadTrack(trackNumber);
                        showScreen();
                    }
                }
                else
                {
                    Console.WriteLine("\nGrant access to device storage!\n");
                }

            }
            else
            {
                Console.WriteLine("\nSwitch on the Player first!\n");
            }
        }
        public void accessOnDevice(ref IPod ipd)
        {
            if(ipd!=null)
            {
                this.ipd = ipd;
            }
        }
        public void showScreen()
        {
            Console.WriteLine("\n*****" + appName + "*****");
            Console.WriteLine("---------------------------");
            if(mf!=null)
            {
                Console.WriteLine("Playing Track: " + mf.getTitle());
            }
            else
            {
                Console.WriteLine("No track is playing");
            }
            Console.WriteLine("Volume: " + loudness);
        }
    }
    class MusicFile
    {
        private String title;
        private String artist;
        private int yearOfRelease;
        private int durationInSeconds;

        public MusicFile()
        {
            this.title = "Empty file";
            this.artist = "N/A";
            this.yearOfRelease = 0;
            this.durationInSeconds = 60;
        }
        public MusicFile(String title, String artist, int yearOfRelease, int durationInSeconds) 
        {
            this.title = title;
            this.artist = artist;
            this.yearOfRelease = yearOfRelease;
            this.durationInSeconds = durationInSeconds;
        }
        public void changeTitle(String title)
        {
            this.title = title;
        }
        public String getTitle()
        {
            return title;
        }
        public String getArstist()
        {
            return artist;
        }
        public int getYearOfRelease()
        {
            return yearOfRelease;
        }
        public int getDurationInSeconds()
        {
            return durationInSeconds;
        }
    }

    class IPod
    {
        private String model;
        private String productionNumber;
        private String os;
        private MusicFile[] musicLibrary = new MusicFile[500];

        public IPod(String model, String productionNumber, String os)
        {
            this.model = model;
            this.productionNumber = productionNumber;
            this.os = os;
        }

        public void storeMusicFile(MusicFile mf)
        {
            bool flag = false;
            for(int i=0; i<musicLibrary.Length; i++)
            {
                if(musicLibrary[i]==null)
                {
                    musicLibrary[i] = mf;
                    flag = true;
                    break;
                }
            }
            if(flag == false)
            {
                Console.WriteLine("\nStorage full!\n");
            }
        }
        public MusicFile loadTrack(int trackNum)
        {
            MusicFile mf=null;
            for(int i=0; i<musicLibrary.Length; i++)
            {
                if(i==trackNum)
                {
                    mf = musicLibrary[i];
                }
            }
            return mf;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPod ipd = new IPod("10pro", "A139901", "ios 12");
            ipd.storeMusicFile(new MusicFile("Nodi", "A. Khan", 2001, 190));
            ipd.storeMusicFile(new MusicFile("Shopno", "Rana Kumar", 1997, 210));
            ipd.storeMusicFile(new MusicFile("Baul", "Dara Nath", 2007, 150));
            ipd.storeMusicFile(new MusicFile("My Love", "Jacky Den", 1991, 290));
            ipd.storeMusicFile(new MusicFile("Bad day", "Dany Pogba", 2012, 310));
            RadioPlayer iRad = new RadioPlayer();
            MusicPlayer iMsc = new MusicPlayer();
            Console.WriteLine("*****Launch Pad*****");
            Console.WriteLine("---------------------\n");
            bool run1=true;
            while(run1)
            {
                Console.WriteLine("1. IRadio \n2. IMusic \n3. Exit \nYour Choice:");
                int choice1 = Convert.ToInt32(Console.ReadLine());
                switch(choice1)
                {
                    case 1:
                        {
                            Console.WriteLine("\n*****IRadio*****");
                            Console.WriteLine("--------------------\n");
                            bool run2 = true;
                            while(run2)
                            {
                                Console.WriteLine("1. Switch \n2. Retune");
                                Console.WriteLine("3. Set Volume \n4. Change Channel");
                                Console.WriteLine("5. Exit app \nYour Choice:");
                                int choice2 = Convert.ToInt32(Console.ReadLine());
                                switch(choice2)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("\n1. On \n2. Off \nChoice:");
                                            int choice4 = Convert.ToInt32(Console.ReadLine());
                                            if(choice4==1)
                                            {
                                                iRad.Switch(true);
                                            }
                                            else if(choice4==2)
                                            {
                                                iRad.Switch(false);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong Input");
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Write("\nEnter frequency: ");
                                            iRad.retune(Convert.ToInt32(Console.ReadLine()));
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Write("\nEnter Volume: ");
                                            iRad.setVolume(Convert.ToInt32(Console.ReadLine()));
                                            break;
                                        }
                                    case 4:
                                        {
                                            iRad.changeChannel();
                                            break;
                                        }
                                    case 5:
                                        {
                                            run2 = false;
                                            Console.WriteLine("\nExiting IRadio...\n");
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("\nWrong Choice!\n");
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            iMsc.accessOnDevice(ref ipd);   
                            Console.WriteLine("\nAccess granted to device storage...\n");
                            Console.WriteLine("\n*****IMusic*****");
                            Console.WriteLine("--------------------\n");
                            bool run3 = true;
                            while(run3)
                            {

                                Console.WriteLine("1. Switch \n2. Play");
                                Console.WriteLine("3. Set Volume \n4. Next");
                                Console.WriteLine("5. Previous \n6. Exit app");
                                Console.WriteLine("Your choice:");
                                int choice3 = Convert.ToInt32(Console.ReadLine());
                                switch (choice3)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("\n1. On \n2. Off \nChoice:");
                                            int choice5 = Convert.ToInt32(Console.ReadLine());
                                            if (choice5 == 1)
                                            {
                                                iMsc.Switch(true);
                                            }
                                            else if (choice5 == 2)
                                            {
                                                iMsc.Switch(false);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong Input");
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("1. Play \n2. Stop \nChoice:");
                                            int choice6 = Convert.ToInt32(Console.ReadLine());
                                            if(choice6==1)
                                            {
                                                iMsc.play(true);
                                            }
                                            else if(choice6==2)
                                            {
                                                iMsc.play(false);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong Input");
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Write("\nEnter Volume: ");
                                            iMsc.setVolume(Convert.ToInt32(Console.ReadLine()));
                                            break;
                                        }
                                    case 4:
                                        {
                                            iMsc.playNext();
                                            break;
                                        }
                                    case 5:
                                        {
                                            iMsc.playPrevious();
                                            break;
                                        }
                                    case 6:
                                        {
                                            run3 = false;
                                            Console.WriteLine("\nExiting IMusic...\n");
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("\nWrong Choice!\n");
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            run1 = false;
                            Console.WriteLine("\nShutting down the device...\n");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nWrong Choice...\n");
                            break;
                        }
                }
            }
            Console.ReadKey();
        }
    }
}