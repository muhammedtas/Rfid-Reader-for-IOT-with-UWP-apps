using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Mfrc522Lib;

namespace ConsoleApp
{
    public class Tools
    {


        public async Task RfidReader()
        {

            try
            {
                var mfrc = new Mfrc522();
                await mfrc.InitIO();
                Debug.WriteLine("InitIO Success");

                while (true)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1)); // Saniyelik saysın. 

                    if (mfrc.IsTagPresent())
                    {
                        Debug.WriteLine("There is a Tah");
                        var uid = mfrc.ReadUid();

                        mfrc.HaltTag();

                        var dialog = new MessageDialog(uid.ToString()) { Title = "A card has been read" };
                        dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                        dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
                        var result = await dialog.ShowAsync();
                        Debug.WriteLine("Success");

                        if ((int)result.Id == 0)
                        {
                            // DO some stuff like sending id to web references
                            //send id to your db web service..

                        }
                        else
                        {
                            continue;
                            //skip your task 

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog("An Error has Occured While Reading...  Inner Exception is " + ex.Message) { Title = "What Da?" };

                var result = await dialog.ShowAsync();
                
            }
            

        }


    }
}
