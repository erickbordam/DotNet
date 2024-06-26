import { makeStyles } from '@mui/material'
import React from 'react'

const useStyles = makeStyles(theme => ({
    root: {
        '& .MuiFormControl-root': {
        with: '90%',
        margin: theme.spacing(1)
    }
    }}));


export default function Form(props) {
  const classes = useStyles();
  const { children, ...other } = props;
    return (
        <form className={classes.root} noValidate autoComplete='off' {...other}>
            {children}
        </form>
  )
}
