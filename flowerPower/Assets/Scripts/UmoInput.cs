using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Pipes;
using System;
using System.IO;
using System.Text;

public static class UmoInput
{

	/******************************************************************************
	/* Event called when UMO application needs to retrieve the player score.
	/* Returns:  player score
	/******************************************************************************/
    public static event Func<int> OnGetScore;

	/******************************************************************************
	/* Event called to set a parameter
	/* Parameters:
	/*		name - parameter name
	/*		value - parameter value
	/******************************************************************************/
    public static event Action<string, float> OnSetParameter;

	/******************************************************************************
	/* Event called to show high score screen
	/* Parameters:
	/*		name - current player name
	/*		score - current player score
	/*		hsTable - list of name - score pairs representing high-score table
	/******************************************************************************/
    public static event Action<string, int, List<KeyValuePair<string, int>>> OnShowHighScores;

	/******************************************************************************
	/* Called during the initialization of the game to establish connection to the
	/* UMO application.
	/* Parameters:
	/*		numInputs - number of inputs the game expects
	/*		parameters - Dictionary of parameter names and their default values
	/******************************************************************************/
    public static void Connect(int numInputs, Dictionary<string, float> parameters)
    {
#if TEST_MODE
        testMode = true;
#else
        try {
            pipe = new NamedPipeClientStream("UmoGamePipe");
            pipe.Connect(500);

            if (!pipe.IsConnected) {
                testMode = true;
                return;
            }
            testMode = false;
            pipeWriter = new BinaryWriter(pipe, Encoding.UTF8);

            pipe.WriteByte(VERSION);
            pipe.WriteByte((byte)numInputs);
            pipe.WriteByte(parameters != null ? (byte)parameters.Count : (byte)0);
            if (parameters != null) {
                foreach (string pn in parameters.Keys) pipeWriter.Write(pn);
                foreach (float pv in parameters.Values) pipeWriter.Write(pv);
                UmoInput.parameters = parameters;
            } else {
                UmoInput.parameters = new Dictionary<string, float>();
            }

            pipe.BeginRead(buf, 0, buf.Length, OnPipeRead, null);
        } catch (Exception) {
            testMode = true; 
        }
#endif
    }
	
	/******************************************************************************
	/* Returns the status of input (on / off).
	/* Parameters:
	/*		index - zero-based input number
	/* Returns:  status of the input
	/******************************************************************************/
    public static bool GetInput(int index)
    {
        if (testMode) return Input.GetKeyDown(KeyCode.Alpha1 + index);
        return inputs[index];
    }

	/******************************************************************************
	/* Returns the pause status (on / off).
	/* Returns:  true if paused, false otherwise
	/******************************************************************************/
    public static bool IsPause { get { return isPaused; } }

	/******************************************************************************
	/* Returns weather the game shoud be restarted.
	/* Returns:  true if the game should be restarted
	/******************************************************************************/
    public static bool IsRestart {
        get {
            bool val = isRestart;
            isRestart = false;
            return val;
        }
    }

	/******************************************************************************
	/* Returns the numeric value of the input.
	/* Parameters:
	/*		index - zero-based input number
	/* Returns:  input value
	/******************************************************************************/
    public static float GetValue(int index)
    {
        return values[index];
    }
	

    private const byte VERSION = 1;

    private static bool testMode = false;
    private static NamedPipeClientStream pipe;
    private static BinaryWriter pipeWriter;
    private static int bufLen = 0;
    private static byte[] buf = new byte[500];
    private static bool[] inputs = new bool[5];
    private static float[] values = new float[5];
    private static bool isPaused = false;
    private static bool isRestart = false;
    private static Dictionary<string, float> parameters;
	
    private static bool inCmd = false;
    private static int cmd = 0;
    private static int cmdLen = 0;

    private static void OnPipeRead(IAsyncResult ar)
    {
        try {
            bufLen += pipe.EndRead(ar);
            if (bufLen >= 4) {
                cmd = buf[0];
                cmdLen = BitConverter.ToInt16(buf, 1);
                if (bufLen >= cmdLen + 3) {
                    int bp = 3;
                    // handle cmd
                    switch (cmd) {
                        case 0: // data
                            for (int i = 0; i < 5; i++) inputs[i] = ((buf[bp] >> i) & 0x01) != 0;
                            bp++;
                            for (int i = 0; i < 5; i++) values[i] = BitConverter.ToSingle(buf, bp + (i * 4));
                            break;
                        case 1: // get
                            string pn = ReadString(buf, ref bp);
                            if (pn == "_score") {
                                if (OnGetScore != null) pipeWriter.Write(OnGetScore());
                                else pipeWriter.Write(-1);
                            }
                            break;
                        case 2: // set
                            pn = ReadString(buf, ref bp);
                            if (pn == "_pause") {
                                isPaused = buf[bp] != 0;
                            } else if (pn == "_restart") {
                                isRestart = buf[bp] != 0;
                            } else {
                                float val = BitConverter.ToSingle(buf, bp);
                                parameters[pn] = val;
                                if (OnSetParameter != null) OnSetParameter(pn, val);
                            }
                            break;
                        case 3: // showHS
                            string name = ReadString(buf, ref bp);
                            int score = ReadInt(buf, ref bp);
                            int cnt = ReadInt(buf, ref bp);
                            List<KeyValuePair<string, int>> hs = new List<KeyValuePair<string, int>>();
                            for (int i = 0; i < cnt; i++) {
                                string nm = ReadString(buf, ref bp);
                                int sc = ReadInt(buf, ref bp);
                                hs.Add(new KeyValuePair<string, int>(nm, sc));
                            }
                            if (OnShowHighScores != null) OnShowHighScores(name, score, hs);
                            break;
                        default:
                            break;
                    }

                    if (bufLen > cmdLen + 3) Array.Copy(buf, cmdLen + 3, buf, 0, bufLen - cmdLen - 3);
                    bufLen = bufLen - cmdLen - 3;
                }
            }
            pipe.BeginRead(buf, bufLen, buf.Length - bufLen, OnPipeRead, null);

        } catch (Exception e) {
            Console.WriteLine(e);
            testMode = true;
        }
    }

    private static string ReadString(byte[] buf, ref int pos)
    {
        int len = (int)BitConverter.ToUInt32(buf, pos);
        pos += 4;
        string res = Encoding.UTF8.GetString(buf, pos, len);
        pos += len;
        return res;
    }

    private static int ReadInt(byte[] buf, ref int pos)
    {
        int res = BitConverter.ToInt32(buf, pos);
        pos += 4;
        return res;
    }

}
